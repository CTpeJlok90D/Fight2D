using UnityEngine;

[CreateAssetMenu(menuName = "Fight/Attack")]
public class Attack : ComboElement
{
	[Header(nameof(Attack))]
	[SerializeField] private int _animationNumer = 0;
	public override void OnBegin(ExecuteInfo info)
	{
		info.Animator.SetInteger("AttackDirection", _animationNumer);
	}
	public override void End(ExecuteInfo info)
	{
		info.Animator.SetInteger("AttackDirection", 0);
	}

}
