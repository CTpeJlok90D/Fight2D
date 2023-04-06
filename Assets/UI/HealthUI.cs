using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
	[SerializeField] private Health _health;
	[SerializeField] private Slider _slider;

	protected void OnEnable()
	{
		_health.HeatlhUpdated.AddListener(OnHealthUpdate);
	}

	protected void OnDisable()
	{
		_health.HeatlhUpdated.RemoveListener(OnHealthUpdate);
	}

	private void OnHealthUpdate(int value)
	{
		_slider.value = value;
	}
}
