using UnityEngine;

[CreateAssetMenu(menuName = "Fight/Block")]
public class Block : ComboElement
{
    [SerializeField] private int _blockDirectionAnimationValue;
    public override void OnBegin(ExecuteInfo info)
    {
        info.Animator.SetInteger("BlockDirection", _blockDirectionAnimationValue);
    }

    public override void End(ExecuteInfo info)
    {
        info.Animator.SetInteger("BlockDirection", 0);
    }
}
