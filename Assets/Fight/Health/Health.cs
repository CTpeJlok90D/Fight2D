using Unity.Netcode;
using UnityEngine;

public class Health : Character—haracteristic
{
    [SerializeField] private Stamina _stamina;
    [SerializeField] private CharacterController2D _character;

    protected new void OnEnable()
    {
        base.OnEnable();
        Out.AddListener(OnDeath);
    }

    protected new void OnDisable()
    {
        base.OnDisable();
        Out.RemoveListener(OnDeath);
    }

    private void OnDeath()
    {
        _stamina.IsRecovering = false;
        _character.DisableControl();
        OnDeathServerRpc();
    }

    [ServerRpc]
    private void OnDeathServerRpc()
    {
        _stamina.IsRecovering = false;
        _character.DisableControl();
        OnDeathClientRpc();
    }

    [ClientRpc]
    private void OnDeathClientRpc()
    {
        _stamina.IsRecovering = false;
        _character.DisableControl();
    }
}
