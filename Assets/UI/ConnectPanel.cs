using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectPanel : MonoBehaviour
{
	[SerializeField] private Button _connectButton;
	[SerializeField] private Button _hostButton;
	[SerializeField] private TMP_InputField _ipField;
	[SerializeField] private TMP_InputField _portField;
	[SerializeField] private GameObject _disconnectPanel;

	protected void OnEnable()
	{
		_connectButton.onClick.AddListener(OnConnectClick);
		_hostButton.onClick.AddListener(OnHostClick);
		NetworkManager.Singleton.OnClientConnectedCallback += OnConnectedToServer;
	}

	protected void OnDisable()
	{
		_connectButton.onClick.RemoveListener(OnConnectClick);
		_hostButton.onClick.RemoveListener(OnHostClick);
		if (NetworkManager.Singleton != null)
		{
			NetworkManager.Singleton.OnClientConnectedCallback -= OnConnectedToServer;
		}
	}

	protected void OnConnectedToServer(ulong id)
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
