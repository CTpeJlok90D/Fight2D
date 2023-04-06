using System;
using Unity.Netcode;
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
    [SerializeField] UnityDictionary<ReactionType, StunTimes> _stunTimesByReaction;

    private CharacterController2D _sender;
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


	public void Block(CharacterController2D blocker, Health blockerHealth)
    {
        if (_isUnblockable == false)
        {
            return;
        }
        ApplyHit(ReactionType.Block, blocker, blockerHealth);
    }

    public void Deflect(CharacterController2D deflector, Health deflectorHealth)
    {
        if (_isDeflectable == false)
        {
            return;
        }
        ApplyHit(ReactionType.Deflect, deflector, deflectorHealth);
    }

    public void DirectHit(CharacterController2D deflector, Health deflectorHealth)
    {
        ApplyHit(ReactionType.None, deflector, deflectorHealth);
	}

    private void ApplyHit(ReactionType type, CharacterController2D deflector, Health deflectorHealth)
    {
		deflector.GiveStun(_stunTimesByReaction[type].RecipientStunTime);
        _sender.GiveStun(_stunTimesByReaction[type].SenderStunTime);
        deflectorHealth.Current -= _stunTimesByReaction[type].RecipientDamage;
	}

	private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

    public Hit Init(CharacterController2D sender)
    {
        _sender = sender;
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
    private struct StunTimes
    {
        public int RecipientDamage;
        public float RecipientStunTime;
        public float SenderStunTime;
    }
}
