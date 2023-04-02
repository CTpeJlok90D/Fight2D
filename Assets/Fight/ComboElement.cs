using UnityEngine;

public abstract class ComboElement : ScriptableObject
{
	[Header(nameof(ComboElement))]
	[SerializeField] private Motion _motion;
	[SerializeField] private Direction[] _blockDirections;
	[SerializeField] private Direction _attackDirection;
	[SerializeField] private int _damage;
	[SerializeField] private bool _infinityDuration;

	private bool _executed = false;

	public Motion Motion => _motion;
	public Direction[] BlockDirections => _blockDirections;
	public Direction AttackDirection => _attackDirection;
	public int Damage => _damage;
	public bool InfinityDuration => _infinityDuration;
	public bool Executed => _executed;

	public virtual void Execute(ExecuteInfo info) { }
	public virtual void OnBegin(ExecuteInfo info) { }
	public virtual void End(ExecuteInfo info) { }
}
