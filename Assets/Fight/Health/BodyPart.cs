using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BodyPart : MonoBehaviour
{
    [SerializeField] private CharacterController2D _owner;
    [SerializeField] private HitHandler _hitHandler;
    [SerializeField] private Health _health;
    private Collider2D _collider;

    public CharacterController2D Owner => _owner;
    public HitHandler HitHandler => _hitHandler;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        Init();
    }
#endif
}
