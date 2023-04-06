using UnityEngine;

[CreateAssetMenu(menuName = "Fight/Block")]
public class Block : ComboElement
{
    [SerializeField] private int _blockDirectionAnimationValue;
    public override void Begin(ExecuteInfo info)
    {
        base.Begin(info);
        info.Animator.SetInteger("BlockDirection", _blockDirectionAnimationValue);
    }

    public override void End(ExecuteInfo info)
    {
        base.End(info);
        info.Animator.SetInteger("BlockDirection", 0);
    }
}
