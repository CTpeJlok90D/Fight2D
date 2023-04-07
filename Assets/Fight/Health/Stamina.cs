using UnityEngine;

public class Stamina : CharacterСharacteristic
{
    [Header(nameof(Stamina))]
    [SerializeField] private int _recoveryPerSecond = 33;
    [SerializeField] private CharacterController2D _character;
    [SerializeField] private float _staminaOutStunTime = 1f;

    private float _currentValue;

    private bool _isRecovering = true;
    public bool IsRecovering 
    {
        get => _isRecovering;
        set => _isRecovering = value;
    }

    protected new void OnEnable()
    {
        base.OnEnable();
        Out.AddListener(OnOut);
    }

    protected new void OnDisable()
    {
        base.OnEnable();
        Out.RemoveListener(OnOut);
    }

    protected void Update()
    {
        RecoverValue();
    }

    private void OnOut()
    {
        _character.GiveStun(_staminaOutStunTime);
    }

    private void RecoverValue()
    {
        if (IsServer && IsRecovering)
        {
            if (_currentValue > 1)
            {
                Current += 1;
                _currentValue = 0;
            }
            _currentValue += Time.deltaTime * _recoveryPerSecond;
        }
    }
}