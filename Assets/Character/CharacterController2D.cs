using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CharacterController2D : NetworkBehaviour
{
	[Header(nameof(CharacterController2D))]
	[SerializeField] private Rigidbody2D _rigidbody2D;
	[SerializeField] private List<Combo> _acceptebleCombos = new();
	[SerializeField] private LookDirection _lookDirection = LookDirection.Left;
	[SerializeField] private CharacterСharacteristic _health;
	[SerializeField] private bool _controlDisabled = false;

	private Combo _currentCombo;
	private Motion _lastMotion;
	private float _lastMotionAge;
	private NetworkVariable<float> _stunTime = new(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

	public LookDirection ThisLookDirection
	{
		get => _lookDirection;
		private set
		{
			_lookDirection = value;
			if (_lookDirection == LookDirection.Left)
			{
				transform.rotation = Quaternion.identity;
			}
			else
			{
				transform.rotation = Quaternion.Euler(0, 180, 0);
			}
		}
	}
	public Motion LastMotion => _lastMotion;
	public float LastMotionAge => _lastMotionAge;
	public bool ControlDisabled => _controlDisabled;
	public Combo CurrentCommbo => _currentCombo;
	public float StunTime => _stunTime.Value;

	protected void OnEnable()
	{
		_health?.Out.AddListener(OnDeath);
		if (_health == null)
		{
			Debug.LogWarning($"{nameof(CharacterСharacteristicUI)} component is empty. Character will not take damage and can't die");
		}
	}

	protected void OnDisable()
	{
		_health?.Out.RemoveListener(OnDeath);
	}


	private void OnDeath()
	{
		DisableControl();
	}

	public void GiveStun(float time)
	{
		StartCoroutine(StunCorutine(time));
	}

	private IEnumerator StunCorutine(float time)
	{
		_stunTime.Value = time;
        _controlDisabled = true;
		while (StunTime > 0)
		{
            _stunTime.Value -= Time.deltaTime;
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

	public void SendApplyMotion(Motion motion, float deltaTime)
	{
		ApplyMotion(motion, deltaTime);
		ApplyMotionServerRpc(motion, deltaTime);
	}

	[ServerRpc]
	private void ApplyMotionServerRpc(Motion motion, float deltaTime) 
	{
		ApplyMotion(motion, deltaTime);
		//ApplyMotionClientRPC(motion, deltaTime);
    }

	//[ClientRpc]
	//private void ApplyMotionClientRPC(Motion motion, float deltaTime)
	//{
	//	ApplyMotion(motion, deltaTime);
	//}


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

	private void ApplyMotion(Motion motion, float deltaTime)
	{
		if (ControlDisabled)
		{
			return;
		}

		if (motion == _lastMotion)
		{
			_lastMotionAge += deltaTime;
			return;
		}
		_lastMotion = motion;
		_lastMotionAge = 0;

		if (_currentCombo != null && _currentCombo.IsLaunched == false)
		{
			_currentCombo = null;
		}

		Combo combo = FindAcceptebleCombo(_lastMotion);
        if (_currentCombo == null || (combo != _currentCombo && _currentCombo.MustBeCanceledByLightBlock == false))
		{
			_currentCombo?.Stop();
			_currentCombo = combo;
			_currentCombo?.TransferMotion(_lastMotion);
			_currentCombo?.Begin();
			return;
		}

		if (_currentCombo.MustBeCanceledByLightBlock && _lastMotion.LightBlock)
		{
			_currentCombo?.Stop();
		}

		_currentCombo?.TransferMotion(_lastMotion);
	}

	public void RotateSelf()
	{
		ThisLookDirection = ThisLookDirection == LookDirection.Left ? LookDirection.Right : LookDirection.Left;
		RotateSelfServerRpc(ThisLookDirection);
	}

	[ServerRpc]
	private void RotateSelfServerRpc(LookDirection direction)
	{
		ThisLookDirection = direction;
		RotateSelfClientRpc(direction);
	}

	[ClientRpc]
	private void RotateSelfClientRpc(LookDirection direction)
	{
		ThisLookDirection = direction;
	}

	public enum LookDirection
	{
		Left = -1,
		Right = 1
	}
}
