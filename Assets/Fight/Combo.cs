using System;
using System.Collections;
using UnityEngine;

public class Combo : MonoBehaviour
{
	[SerializeField] private UnityDictionary<TimeInterval, ComboElement> _combatElementByTime;
	[SerializeField] private Rigidbody2D _characterRigidbody;
	[SerializeField] private Animator _animator;
	[SerializeField] private CharacterController2D _character;
	[SerializeField] private HitSpawner _hitSpawner;
	[SerializeField] private bool _mustBeCanceledByLightBlock;

	private float _timer = 0;
	private Motion _lastMotion;
	private Coroutine _coroutine;
	private ComboElement _currentComboElement;
	private bool _comboElementIsLaunched = false;

	public ComboElement CurrentComboElement => _currentComboElement;
	public bool IsLaunched => _coroutine != null;
	public bool MustBeCanceledByLightBlock => _mustBeCanceledByLightBlock;

	public ExecuteInfo ExecuteInfo => new()
	{
		CharacterRigidbody = _characterRigidbody,
		Animator = _animator,
		Character = _character,
		HitSpawner = _hitSpawner
	};

	public void Begin()
	{
		_coroutine = StartCoroutine(BeginComboTimerCorutine());
	}

	public void Stop()
	{
		if (_coroutine != null)
		{
			StopCoroutine(_coroutine);
		}
		_coroutine = null;
		if (_comboElementIsLaunched == true)
		{
			_currentComboElement?.End(ExecuteInfo);
			_comboElementIsLaunched = false;
		}
	}

	private IEnumerator BeginComboTimerCorutine()
	{
		_timer = 0;
		_currentComboElement = FindComboElementByTyme(_timer);
		_currentComboElement?.Begin(ExecuteInfo);
		_comboElementIsLaunched = true;
		while (_timer < _combatElementByTime.Keys[^1].MaxAcceptebleTime)
		{
            if (_currentComboElement == null)
			{
				break;
			}

            _currentComboElement.Execute(ExecuteInfo);

			if (_currentComboElement.InfinityDuration == false)
			{
				_timer += Time.deltaTime;
			}
			ComboElement newComboElement = FindComboElementByTyme(_timer);
			if ((newComboElement == null || newComboElement != _currentComboElement) && _comboElementIsLaunched)
			{
				_currentComboElement?.End(ExecuteInfo);
				_comboElementIsLaunched = false;
			}
			if (newComboElement != null && _lastMotion == newComboElement.Motion && _comboElementIsLaunched == false)
			{
				_currentComboElement = newComboElement;
				_currentComboElement?.Begin(ExecuteInfo);
				_comboElementIsLaunched = true;
			}
			yield return null;
		}
		Stop();
	}

	public void TransferMotion(Motion motion)
	{
		_lastMotion = motion;
	}

	public ComboElement FindComboElementByTyme(float time)
	{
		foreach (TimeInterval variable in _combatElementByTime.Keys)
		{
			if (variable == time)
			{
				return _combatElementByTime[variable];
			}
		}
		return null;
	}


	[Serializable]
	public class TimeInterval
	{
		[SerializeField] private float _minAcceptebleTime;
		[SerializeField] private float _maxAcceptebleTime;

		public float MinAcceptebleTime => _minAcceptebleTime;
		public float MaxAcceptebleTime => _maxAcceptebleTime;

		public TimeInterval(float minAcceptebleTime, float maxAcceptebleTime)
		{
			_minAcceptebleTime = minAcceptebleTime;
			_maxAcceptebleTime = maxAcceptebleTime;
		}

		public bool Include(float time)
		{
			return this == time;
		}

		public override bool Equals(object obj)
		{
			return obj is TimeInterval interval &&
				   _minAcceptebleTime == interval._minAcceptebleTime &&
				   _maxAcceptebleTime == interval._maxAcceptebleTime &&
				   MinAcceptebleTime == interval.MinAcceptebleTime &&
				   MaxAcceptebleTime == interval.MaxAcceptebleTime;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_minAcceptebleTime, _maxAcceptebleTime, MinAcceptebleTime, MaxAcceptebleTime);
		}

		public static bool operator ==(TimeInterval interval, float time)
		{
			return interval._minAcceptebleTime <= time && interval._maxAcceptebleTime >= time;
		}

		public static bool operator !=(TimeInterval interval, float time)
		{
			return interval._minAcceptebleTime >= time || interval._maxAcceptebleTime <= time;
		}
	}
}