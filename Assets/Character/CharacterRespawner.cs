using Unity.Netcode;
using UnityEngine;

public class CharacterRespawner : NetworkBehaviour
{
	[SerializeField] private CharacterController2D _character;
	[SerializeField] private Character—haracteristic _health;
	[SerializeField] private Vector2 _spawnpoint;

	public void Respawn()
	{
        _character.EnableControl();
        RespawnServerRpc();
	}

	[ServerRpc]
	private void RespawnServerRpc()
	{
		_character.transform.position = _spawnpoint;
		_health.Current = _health.Max;
	}
}
