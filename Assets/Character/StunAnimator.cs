using UnityEngine;

public class StunAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController2D _character;

    private void Update()
    {
        _animator.SetFloat("StunTime", _character.StunTime);
    }
}
