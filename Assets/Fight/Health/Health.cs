using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class Health : NetworkBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    [SerializeField] private NetworkVariable<int> _health = new(100, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    [SerializeField] private UnityEvent _death;
    [SerializeField] private UnityEvent<int> _healthUpdated;

    public int Max => _maxHealth;
    public int Min => _minHealth;
    public UnityEvent Death => _death;
    public UnityEvent<int> HeatlhUpdated => _healthUpdated;
    public int Current
    {
        get => _health.Value;
        set
        {
            _health.Value = Mathf.Clamp(value, _minHealth, _maxHealth);
            _healthUpdated.Invoke(Current);
            if (Current == 0)
            {
                _death.Invoke();
            }
        }
    }

	protected void OnEnable()
	{
        _health.OnValueChanged += OnHealthValueChanged;
	}

	protected void OnDisable()
	{
		_health.OnValueChanged -= OnHealthValueChanged;
	}

    private void OnHealthValueChanged(int value, int OldValue)
    {
		_healthUpdated.Invoke(Current);
		if (Current == 0)
		{
			_death.Invoke();
		}
	}
}
