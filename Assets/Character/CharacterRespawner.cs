using Unity.Netcode;
using UnityEngine;

public class CharacterRespawner : MonoBehaviour
{
	[SerializeField] private CharacterController2D _character;
	[SerializeField] private Character—haracteristic _health;

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
