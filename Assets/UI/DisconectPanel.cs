using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class DisconectPanel : MonoBehaviour
{
	[SerializeField] private Button _disconnectButton;
	[SerializeField] private Button _respawnButton;
	[SerializeField] private GameObject _connectPanel;

	private CharacterRespawner _respawner;

	protected void OnEnable()
	{
		NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconect;
		_disconnectButton.onClick.AddListener(OnDisconectClick);
		_respawnButton.onClick.AddListener(OnRespawnClick);
	}

	protected void OnDisable()
	{
		if (NetworkManager.Singleton != null)
		{
			NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconect;
		}
		_disconnectButton.onClick.RemoveListener(OnDisconectClick);
		_respawnButton.onClick.RemoveListener(OnRespawnClick);
	}

	private void OnClientDisconect(ulong id)
	{
		if (id == NetworkManager.Singleton.LocalClientId)
		{
			_connectPanel.SetActive(true);
			gameObject.SetActive(false);
		}
	}

	private void OnDisconectClick()
	{
		NetworkManager.Singleton.Shutdown();
		OnClientDisconect(NetworkManager.Singleton.LocalClientId);
	}

	private void OnRespawnClick()
	{
		if (_respawner == null)
		{
			_respawner = NetworkManager.Singleton.LocalClient.PlayerObject.GetComponent<CharacterRespawner>();
		}
		_respawner.Respawn();
	}
}