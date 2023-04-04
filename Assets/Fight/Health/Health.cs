using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _health;
    [SerializeField] private UnityEvent _death;
    [SerializeField] private UnityEvent _healthUpdated;

    public float Max => _maxHealth;
    public float Min => _minHealth;
    public UnityEvent Death => _death;
    public UnityEvent HeatlhUpdated => _healthUpdated;
    public float Current
    {
        get => _health;
        set
        {
            _health = Mathf.Clamp(value, _minHealth, _maxHealth);
            _healthUpdated.Invoke();
            if (_health == 0)
            {
                _death.Invoke();
            }
        }
    }
}
