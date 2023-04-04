using UnityEngine;

public class Bot : CharacterController2D
{
    [Header("Bot")]
    [SerializeField] private Motion _currentMotion;

    private void Update()
    {
        ApplyMotion(_currentMotion, Time.deltaTime);
    }
}
