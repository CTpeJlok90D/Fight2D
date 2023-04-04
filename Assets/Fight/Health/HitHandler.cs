using UnityEngine;

public class HitHandler : MonoBehaviour
{
    [SerializeField] private CharacterController2D _character;
    [SerializeField] private Health _health;

    public void HandleHit(Hit hit)
    {
        if (_character.ControlDisabled)
        {
            hit.DirectHit(_character, _health);
            return;
        }

        if (_character.LastMotion == hit.ParryMotion && _character.LastMotionAge < hit.DeflectTime)
        {
            hit.Deflect(_character, _health);
            return;
        }

        if (_character.LastMotion.Block == hit.BlockDirection)
        {
            hit.Block(_character, _health);
            return;
        }

        hit.DirectHit(_character, _health);
    }
}
