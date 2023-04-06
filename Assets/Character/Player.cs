using UnityEngine;
using UnityEngine.InputSystem;

public class Player : CharacterController2D
{
	private Actions _actions;
	private bool _lightBlock;

	public Vector2 MoveInput => _actions.Fight.Move.ReadValue<Vector2>();
	public Vector2 AttackInput => _actions.Fight.Attack.ReadValue<Vector2>();
	public Vector2 Block => _actions.Fight.Block.ReadValue<Vector2>();

	private Motion CurrentMotionInput => new()
	{
		Attack = DirectionByVector2(AttackInput),
		Move = DirectionByVector2(MoveInput),
		Block = DirectionByVector2(Block),
		LightBlock = _lightBlock
	};

	protected void Update()
	{
		if (IsClient && IsLocalPlayer)
		{
			SendApplyMotion(CurrentMotionInput, Time.deltaTime);
		}
	}

	protected void Awake()
	{
		_actions = new Actions();
		_actions.Fight.Move.Enable();
		_actions.Fight.Attack.Enable();
		_actions.Fight.SwitchStance.Enable();
		_actions.Fight.RotateSelf.Enable();
	}
    protected new void OnEnable()
    {
		base.OnEnable();
		_actions.Fight.SwitchStance.started += EnableBlockStance;
		_actions.Fight.SwitchStance.canceled += DisableBlockStance;
		_actions.Fight.RotateSelf.started += RotateSelf;
	}

    protected new void OnDisable()
    {
		base.OnDisable();
        _actions.Fight.SwitchStance.started -= EnableBlockStance;
        _actions.Fight.SwitchStance.canceled -= DisableBlockStance;
		_actions.Fight.RotateSelf.started -= RotateSelf;
	}

	private void RotateSelf(InputAction.CallbackContext context)
	{
		if (IsClient && IsLocalPlayer)
		{
			RotateSelf();
		}
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
		_lightBlock = true;

        _actions.Fight.Attack.Disable();
		_actions.Fight.Block.Enable();
    }

    private void DisableBlockStance()
	{
        _lightBlock = false;

        _actions.Fight.Attack.Enable();
        _actions.Fight.Block.Disable();
    }

	public Direction DirectionByVector2(Vector2 vector)
	{
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