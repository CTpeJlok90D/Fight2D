using UnityEngine;
using UnityEngine.Events;

public class HitHandler : MonoBehaviour
{
    [SerializeField] private CharacterController2D _character;
    [SerializeField] private CharacterÑharacteristic _health;
    [SerializeField] private Stamina _stamina;
    [SerializeField] private UnityEvent _blocked;
    [SerializeField] private UnityEvent _deflected;

    public CharacterInfo CharacterInfo => new()
    {
        Character = _character,
        Health = _health,
        Stamina = _stamina,
    };

    public UnityEvent Blocked => _blocked;
    public UnityEvent Deflected => _deflected;

    public void HandleHit(Hit hit)
    {
		if (_character.ControlDisabled)
        {
            hit.DirectHit(CharacterInfo);
            return;
        }

        if (_character.LastMotion == hit.ParryMotion && _character.LastMotionAge < hit.DeflectTime)
        {
            hit.Deflect(CharacterInfo);
            _deflected.Invoke();
			return;
        }

        if (_character.LastMotion.Block == hit.BlockDirection || (hit.IsBlockingByLightBlock && _character.LastMotion.LightBlock && _character.LastMotion.Block == Direction.None))
        {
            hit.Block(CharacterInfo);
            _blocked.Invoke();
			return;
        }

        hit.DirectHit(CharacterInfo);
    }
}
