using UnityEngine;

public class Player : CharacterController2D
{
	private Actions _actions;

	public Vector2 MoveInput => _actions.Fight.Move.ReadValue<Vector2>();
	public Vector2 AttackInput => _actions.Fight.Attack.ReadValue<Vector2>();
	public Vector2 Block => _actions.Fight.Block.ReadValue<Vector2>();

	private Motion CurrentMotion => new()
	{
		Attack = DirectionByVector2(AttackInput),
		Move = DirectionByVector2(MoveInput),
		Block = DirectionByVector2(Block)
	};

	private void Awake()
	{
		_actions = new Actions();
		_actions.Fight.Move.Enable();
		_actions.Fight.Attack.Enable();
	}

	protected void Update()
	{
		ApplyMotion(CurrentMotion);
	}

	public Direction DirectionByVector2(Vector2 vector)
	{
		// TODO: Придумать алгорим получше...
		if (vector == Vector2.zero)
		{
			return Direction.None;
		}

		if (Mathf.Abs(vector.y) > Mathf.Abs(vector.x))
		{
			if (vector.y > 0)
			{
				return Direction.Up;
			}
			return Direction.Down;
		}
		if (vector.x > 0)
		{
			if (ThisLookDirection is LookDirection.Left)
			{
				return Direction.Back;
			}
			else
			{
				return Direction.Forward;
			}
		}
		if (ThisLookDirection is LookDirection.Left)
		{
			return Direction.Forward;
		}
		else
		{
			return Direction.Back;
		}
	}
}