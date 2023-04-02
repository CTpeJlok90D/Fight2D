using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	[Header(nameof(CharacterController2D))]
	[SerializeField] private Rigidbody2D _rigidbody2D;
	[SerializeField] private List<Combo> _acceptebleCombos = new();
	[SerializeField] private LookDirection _lookDirection = LookDirection.Left;

	private Combo _currentCombo;
	public bool ControlDisabled = false;

	public LookDirection ThisLookDirection => _lookDirection;

	public void DisableControl()
	{
		ControlDisabled = true;
	}

	public void EnableControl()
	{
		ControlDisabled = false;
	}

	public void ApplyMotion(Motion motion) 
	{
		if (ControlDisabled)
		{
			return;
		}
		Combo combo = FindAcceptebleCombo(motion);
		if (combo != _currentCombo)
		{
			_currentCombo?.Stop();
			_currentCombo = combo;
			_currentCombo?.Begin();
		}

		_currentCombo?.TransferMotion(motion);
	}

	private Combo FindAcceptebleCombo(Motion motion)
	{
		foreach (Combo combo in _acceptebleCombos)
		{
			ComboElement comboElement = combo.FindComboElementByTyme(0);
			if (comboElement.Motion == motion)
			{
				return combo;
			}
		}
		return null;
	}

	public enum LookDirection
	{
		Left = -1,
		Right = 1
	}
}
