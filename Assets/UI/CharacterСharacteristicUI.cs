using UnityEngine;
using UnityEngine.UI;

public class Character—haracteristicUI : MonoBehaviour
{
	[SerializeField] private Character—haracteristic _health;
	[SerializeField] private Slider _slider;

    protected void Awake()
    {
		OnHealthUpdate(_health.Current);
    }

    protected void OnEnable()
	{
		_health.ValueUpdated.AddListener(OnHealthUpdate);
	}

	protected void OnDisable()
	{
		_health.ValueUpdated.RemoveListener(OnHealthUpdate);
	}

	private void OnHealthUpdate(int value)
	{
		_slider.value = value;
	}
}
