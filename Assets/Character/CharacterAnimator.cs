using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController2D _character;
	[SerializeField] private HitHandler _hitHandler;
	[SerializeField] private Character—haracteristic _health;

	private void OnEnable()
	{
		_hitHandler.Deflected.AddListener(OnBlocked);
		_hitHandler.Blocked.AddListener(OnBlocked);
		_health.ValueUpdated.AddListener(OnHealthChange);
	}

	private void OnDisable()
	{
		_hitHandler.Deflected.RemoveListener(OnBlocked);
		_hitHandler.Blocked.RemoveListener(OnBlocked);
		_health.ValueUpdated.RemoveListener(OnHealthChange);
	}

	private void OnHealthChange(int newValue)
	{
		_animator.SetBool("IsDead", newValue == 0);
	}

	private void OnBlocked()
	{
		_animator.SetTrigger("Blocked");
	}

	private void Update()
    {
		_animator.SetBool("LightBlock", _character.LastMotion.LightBlock);
        _animator.SetFloat("StunTime", _character.StunTime);
    }
}
