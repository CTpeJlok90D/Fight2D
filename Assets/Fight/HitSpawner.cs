using UnityEngine;

public class HitSpawner : MonoBehaviour
{
    [SerializeField] private CharacterController2D _sender;

    public void Spawn()
    {
        if (_sender.CurrentCommbo.CurrentComboElement.Hit)
        {
            Instantiate(_sender.CurrentCommbo.CurrentComboElement.Hit, transform).Init(_sender);
        }
    }
}
