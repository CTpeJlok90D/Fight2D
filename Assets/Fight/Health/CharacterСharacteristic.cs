using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class Character—haracteristic : NetworkBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _minValue;
    [SerializeField] private NetworkVariable<int> _current = new(100, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
    [SerializeField] private UnityEvent _out;
    [SerializeField] private UnityEvent<int> _valueUpdated;

    public int Max => _maxValue;
    public int Min => _minValue;
    public UnityEvent Out => _out;
    public UnityEvent<int> ValueUpdated => _valueUpdated;
    public int Current
    {
        get => _current.Value;
        set
        {
            _current.Value = Mathf.Clamp(value, _minValue, _maxValue);
            _valueUpdated.Invoke(Current);
            if (Current == 0)
            {
                _out.Invoke();
            }
        }
    }
    protected void OnEnable()
	{
        _current.OnValueChanged += OnCurrentValueChanged;
	}

	protected void OnDisable()
	{
		_current.OnValueChanged -= OnCurrentValueChanged;
	}

    private void OnCurrentValueChanged(int value, int OldValue)
    {
		_valueUpdated.Invoke(Current);
		if (Current == 0)
		{
			_out.Invoke();
		}
	}
}
