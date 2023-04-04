using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	[Header(nameof(CharacterController2D))]
	[SerializeField] private Rigidbody2D _rigidbody2D;
	[SerializeField] private List<Combo> _acceptebleCombos = new();
	[SerializeField] private LookDirection _lookDirection = LookDirection.Left;

	private Combo _currentCombo;
	private Motion _LastMotion;
	private float _lastMotionAge;
	[SerializeField] private bool _controlDisabled = false;
	private float _stunTime = 0f;

	public LookDirection ThisLookDirection => _lookDirection;
	public Motion LastMotion => _LastMotion;
	public float LastMotionAge => _lastMotionAge;
	public bool ControlDisabled => _controlDisabled;
	public Combo CurrentCommbo => _currentCombo;
	public float StunTime => _stunTime;
	

    public void GiveStun(float time)
    {
		StartCoroutine(StunCorutine(time));
    }

	private IEnumerator StunCorutine(float time)
	{
		_stunTime = time;
        _controlDisabled = true;
        while (_stunTime > 0)
		{
            _stunTime -= Time.deltaTime;
			yield return null;
		}
        _controlDisabled = false;
    }

    public void DisableControl()
	{
		_controlDisabled = true;
	}

	public void EnableControl()
	{
		_controlDisabled = false;
	}

	public void ApplyMotion(Motion motion, float deltaTime) 
	{
		if (ControlDisabled || motion == _LastMotion)
		{
			_lastMotionAge += deltaTime;
            return;
		}

		_lastMotionAge = 0;

		_LastMotion = motion;

        Combo combo = FindAcceptebleCombo(_LastMotion);
		if (combo != _currentCombo)
		{
			_currentCombo?.Stop();
			_currentCombo = combo;
            _currentCombo?.TransferMotion(_LastMotion);
            _currentCombo?.Begin();
			return;
		}

        _currentCombo?.TransferMotion(_LastMotion);
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
