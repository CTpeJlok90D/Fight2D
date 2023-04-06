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

	private UnityEvent _begun = new();
	private UnityEvent _endned = new();

	public Motion Motion => _motion;
	public bool InfinityDuration => _infinityDuration;
	public float TimeToHit => _timeToHit;

	public virtual void Execute(ExecuteInfo info) 
	{
		
	}
	public virtual void Begin(ExecuteInfo info) 
	{
		info.HitSpawner.SpawnIn(_timeToHit, _hitPrefab, _endned);
		_begun.Invoke();
	}
	public virtual void End(ExecuteInfo info) 
	{
		_endned.Invoke();
	}
}
