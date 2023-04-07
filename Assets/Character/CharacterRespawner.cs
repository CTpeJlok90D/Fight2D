using Unity.Netcode;
using UnityEngine;

public class CharacterRespawner : MonoBehaviour
{
	[SerializeField] private CharacterController2D _character;
	[SerializeField] private Health _health;

	public void Respawn()
	{
		RespawnServerRpc();
	}

	[ServerRpc]
	private void RespawnServerRpc()
	{
		_character.EnableControl();
		_health.Current = _health.Max;
	}
}
