using Unity.Netcode;
using UnityEngine;

public class CharacterRespawner : MonoBehaviour
{
	[SerializeField] private CharacterController2D _character;
	[SerializeField] private Health _health;

	public void Respawn()
	{
		LocalRespawn();
		RespawnServerRpc();
	}

	[ServerRpc]
	private void RespawnServerRpc()
	{
		LocalRespawn();
		RespawnClientRpc();
	}

	[ClientRpc]
	private void RespawnClientRpc()
	{
		LocalRespawn();
	}

	private void LocalRespawn()
	{
		NetworkManager.Singleton.Shutdown();
		NetworkManager.Singleton.StartClient();
	}
}
