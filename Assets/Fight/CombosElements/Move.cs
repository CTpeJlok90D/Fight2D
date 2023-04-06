using UnityEngine;

[CreateAssetMenu(menuName = "Fight/Move")]
public class Move : ComboElement
{
	[Header(nameof(Move))]
	[SerializeField] private float _moveSpeed;
	[SerializeField] private int _moveDirection;

	public override void Execute(ExecuteInfo info)
	{
		Rigidbody2D character = info.CharacterRigidbody;

		character.transform.Translate(Vector3.left * _moveDirection * _moveSpeed * Time.deltaTime);
	}

	public override void End(ExecuteInfo info)
	{
		base.End(info);
		info.Animator.SetInteger("MoveDirection", 0);
	}

	public override void Begin(ExecuteInfo info) 
	{
		base.Begin(info);
		info.Animator.SetInteger("MoveDirection", _moveDirection);
	}

	private void OnValidate()
	{
		if (_moveDirection > 0)
		{
			_moveDirection = 1;
		}
		if (_moveDirection < 0)
		{
			_moveDirection = -1;
		}
	}
}
