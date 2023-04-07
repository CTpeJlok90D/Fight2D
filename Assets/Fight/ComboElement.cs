using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public abstract class ComboElement : ScriptableObject
{
	[Header(nameof(ComboElement))]
	[SerializeField] private Motion _motion;
	[SerializeField] private bool _infinityDuration;
	[SerializeField] private Hit _hitPrefab;
	[SerializeField] private float _timeToHit;
	[SerializeField] private bool _recoverStaminaWhileExecute = false;
    [SerializeField] private int _staminaToUse = 0;

    private UnityEvent _begun = new();
	private UnityEvent _endned = new();
    private bool _lauched = false;

	public Motion Motion => _motion;
	public bool InfinityDuration => _infinityDuration;
	public float TimeToHit => _timeToHit;
    public int StaminaToUse => _staminaToUse;
    public bool Launched => _lauched;

	public virtual void Execute(ExecuteInfo info)
    {
        if (_lauched == false)
        {
            return;
        }
    }
	public virtual void Begin(ExecuteInfo info) 
	{
        _lauched = info.Stamina.Current > _staminaToUse;
        if (_lauched == false)
        {
            return;
        }
        if (NetworkManager.Singleton.IsServer)
        {
            info.HitSpawner.SpawnIn(_timeToHit, _hitPrefab, _endned);
            info.Stamina.IsRecovering = _recoverStaminaWhileExecute;
        }
        _begun.Invoke();
	}
	public virtual void End(ExecuteInfo info)
    {
        if (_lauched == false)
        {
            return;
        }
        if (NetworkManager.Singleton.IsServer)
        {
            info.Stamina.IsRecovering = _recoverStaminaWhileExecute == false;
            info.Stamina.Current -= _staminaToUse;
        }
        _endned.Invoke();
	}
}
