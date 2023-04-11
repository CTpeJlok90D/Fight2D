using Unity.Netcode;
using UnityEngine;

public class CharacterRespawner : NetworkBehaviour
{
	[SerializeField] private CharacterController2D _character;
	[SerializeField] private Character—haracteristic _health;
	[SerializeField] private Stamina _stamina;
    [SerializeField] private Vector2 _spawnpoint;

	public void Respawn()
	{
        _character.EnableControl();
        _character.transform.position = _spawnpoint;
        RespawnServerRpc();
	}

	[ServerRpc]
	private void RespawnServerRpc()
	{
		_character.transform.position = _spawnpoint;
		_health.Current = _health.Max;
		_stamina.IsRecovering = true;

        RespawnClientRpc();

    }

	[ClientRpc]
	private void RespawnClientRpc()
	{
        _character.transform.position = _spawnpoint;
        _character.EnableControl();
    }
}
