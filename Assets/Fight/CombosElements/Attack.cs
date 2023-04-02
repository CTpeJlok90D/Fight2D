using UnityEngine;

[CreateAssetMenu(menuName = "Fight/Attack")]
public class Attack : ComboElement
{
	[Header(nameof(Attack))]
	[SerializeField] private int _animationNumer = 0;
	public override void OnBegin(ExecuteInfo info)
	{
		info.Animator.SetInteger("AttackDirection", _animationNumer);
		info.Character.DisableControl();
		Debug.Log("Started");
	}
	public override void End(ExecuteInfo info)
	{
		info.Animator.SetInteger("AttackDirection", 0);
		info.Character.EnableControl();
		Debug.Log("Stoped");
	}

}
