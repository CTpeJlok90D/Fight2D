using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Hit : MonoBehaviour
{
    [SerializeField] private float _liveTime;
    [SerializeField] private Direction _blockDirection;
    [SerializeField] private Motion _deflectMotion;
    [SerializeField] private float _deflectTime;
    [SerializeField] private bool _isUnblockable;
    [SerializeField] private bool _isDeflectable;
    [SerializeField] private bool _isBlockingByLightBlock;
    [SerializeField] UnityDictionary<ReactionType, HitResult> _hitResult;

    private CharacterController2D _sender;
    private Stamina _senderStamina;
    private CharacterController2D _target;
    private Collider2D _collider;

    public CharacterController2D Sender => _sender;
    public Collider2D Collider => _collider;
    public Direction BlockDirection => _blockDirection;
    public Motion ParryMotion => _deflectMotion;
    public float DeflectTime => _deflectTime;
    public bool IsUnblockable => _isUnblockable;
    public bool IsDeflectable => _isDeflectable;
    public bool IsBlockingByLightBlock => _isBlockingByLightBlock;


	public void Block(CharacterInfo info)
    {
        if (_isUnblockable == false)
        {
            return;
        }
        ApplyHit(ReactionType.Block, info);
    }

    public void Deflect(CharacterInfo info)
    {
        if (_isDeflectable == false)
        {
            return;
        }
        ApplyHit(ReactionType.Deflect, info);
    }

    public void DirectHit(CharacterInfo info)
    {
        ApplyHit(ReactionType.None, info);
	}

    private void ApplyHit(ReactionType type, CharacterInfo info)
    {
        info.Character.GiveStun(_hitResult[type].RecipientStunTime);
        _sender.GiveStun(_hitResult[type].SenderStunTime);
        info.Health.Current -= _hitResult[type].RecipientDamage;
        info.Stamina.Current -= _hitResult[type].RecipientStuminaDamage;
        _senderStamina.Current -= _hitResult[type].SenderStaminaDamage;
    }

	private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

    public Hit Init(CharacterController2D sender, Stamina senderStamina)
    {
        _sender = sender;
        _senderStamina = senderStamina;
        return this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_target != null)
        {
            return;
        }
        if (collision.gameObject.TryGetComponent(out BodyPart part))
        {
            _target = part.Owner;
            if (part.Owner == _sender)
            {
                return;
            }

            part.HitHandler.HandleHit(this);

            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _liveTime -= Time.deltaTime;
        if (_liveTime < 0)
        {
            Destroy(gameObject);
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }
#endif

    private enum ReactionType
    {
        None,
        Block,
        Deflect,
    }

    [Serializable]
    private struct HitResult
    {
        public int RecipientDamage;
        public float RecipientStunTime;
        public float SenderStunTime;
        public int RecipientStuminaDamage;
        public int SenderStaminaDamage;
    }
}
