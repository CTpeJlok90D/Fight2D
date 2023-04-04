using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : CharacterController2D
{
	private Actions _actions;

	public Vector2 MoveInput => _actions.Fight.Move.ReadValue<Vector2>();
	public Vector2 AttackInput => _actions.Fight.Attack.ReadValue<Vector2>();
	public Vector2 Block => _actions.Fight.Block.ReadValue<Vector2>();

	private Motion CurrentMotionInput => new()
	{
		Attack = DirectionByVector2(AttackInput),
		Move = DirectionByVector2(MoveInput),
		Block = DirectionByVector2(Block),
		LightBlock = LightBlock
    };

	private bool LightBlock;

    private void Awake()
	{
		_actions = new Actions();
		_actions.Fight.Move.Enable();
		_actions.Fight.Attack.Enable();
		_actions.Fight.SwitchStance.Enable();
	}
    private void OnEnable()
    {
		_actions.Fight.SwitchStance.started += EnableBlockStance;
		_actions.Fight.SwitchStance.canceled += DisableBlockStance;
    }

    private void OnDisable()
    {
        _actions.Fight.SwitchStance.started -= EnableBlockStance;
        _actions.Fight.SwitchStance.canceled -= DisableBlockStance;
    }

    private void EnableBlockStance(InputAction.CallbackContext context)
	{
		EnableBlockStance();

    }

    private void DisableBlockStance(InputAction.CallbackContext context)
	{
		DisableBlockStance();

    }

    private void EnableBlockStance()
    {
		LightBlock = true;

        _actions.Fight.Attack.Disable();
		_actions.Fight.Block.Enable();
    }

    private void DisableBlockStance()
	{
        LightBlock = false;

        _actions.Fight.Attack.Enable();
        _actions.Fight.Block.Disable();
    }

    protected void Update()
	{
		ApplyMotion(CurrentMotionInput, Time.deltaTime);
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