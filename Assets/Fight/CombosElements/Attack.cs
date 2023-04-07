using UnityEngine;

[CreateAssetMenu(menuName = "Fight/Attack")]
public class Attack : ComboElement
{
	[Header(nameof(Attack))]
	[SerializeField] private int _animationNumer = 0;
	public override void Begin(ExecuteInfo info)
	{
        base.Begin(info);
        if (Launched == false)
        {
            return;
        }
        info.Animator.SetInteger("AttackIndex", _animationNumer);
	}
	public override void End(ExecuteInfo info)
	{
        if (Launched == false)
        {
            return;
        }
        base.End(info); 
        info.Animator.SetInteger("AttackIndex", 0);
	}

}
