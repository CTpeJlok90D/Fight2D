using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class ConnectPanel : MonoBehaviour
{
	[SerializeField] private Button _connectButton;
	[SerializeField] private Button _hostButton;
	[SerializeField] private TMP_InputField _ipField;
	[SerializeField] private TMP_InputField _portField;
	[SerializeField] private GameObject _disconnectPanel;
	[SerializeField] private UnityTransport _transport;

	private ushort _oldPort = 7777;

    private void Awake()
    {
		_ipField.text = _transport.ConnectionData.Address;
        _portField.text = _transport.ConnectionData.Port.ToString();
    }

    protected void OnEnable()
	{
		_connectButton.onClick.AddListener(OnConnectClick);
		_hostButton.onClick.AddListener(OnHostClick);
		_ipField.onEndEdit.AddListener(OnIpFieldEndEdit);
        _portField.onEndEdit.AddListener(OnPortFieldEdit);
		NetworkManager.Singleton.OnClientConnectedCallback += OnConnectedToServer;
	}

	protected void OnDisable()
	{
		_connectButton.onClick.RemoveListener(OnConnectClick);
		_hostButton.onClick.RemoveListener(OnHostClick);
        _ipField.onEndEdit.RemoveListener(OnIpFieldEndEdit);
        _portField.onEndEdit.RemoveListener(OnPortFieldEdit);
        if (NetworkManager.Singleton != null)
		{
			NetworkManager.Singleton.OnClientConnectedCallback -= OnConnectedToServer;
		}
	}


	private void OnIpFieldEndEdit(string newValue)
	{
        _transport.ConnectionData.Address = newValue;

    }

	private void OnPortFieldEdit(string newValue)
	{
		ushort port;
        try
		{
            port = Convert.ToUInt16(newValue);
            _oldPort = port;
        }
		catch
		{
            _portField.text = _oldPort.ToString();
        }
        _transport.ConnectionData.Port = _oldPort;
    }

	private void OnConnectedToServer(ulong id)
	{
		if (id == NetworkManager.Singleton.LocalClientId)
		{
			_disconnectPanel.SetActive(true);
			gameObject.SetActive(false);
		}
	}

	private void OnConnectClick()
	{
		NetworkManager.Singleton.StartClient();
	}

	private void OnHostClick()
	{
		NetworkManager.Singleton.StartHost();
	}
}
