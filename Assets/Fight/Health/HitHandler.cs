using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class HitHandler : MonoBehaviour
{
    [SerializeField] private CharacterController2D _character;
    [SerializeField] private Health _health;
    [SerializeField] private UnityEvent _blocked;
    [SerializeField] private UnityEvent _deflected;

    public UnityEvent Blocked => _blocked;
    public UnityEvent Deflected => _deflected;

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
            _deflected.Invoke();
			return;
        }

        if (_character.LastMotion.Block == hit.BlockDirection || (hit.IsBlockingByLightBlock && _character.LastMotion.LightBlock && _character.LastMotion.Block == Direction.None))
        {
            hit.Block(_character, _health);
            _blocked.Invoke();
			return;
        }

        hit.DirectHit(_character, _health);
    }
}
