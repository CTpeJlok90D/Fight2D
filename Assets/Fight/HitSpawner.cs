using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class HitSpawner : NetworkBehaviour
{
	[SerializeField] private CharacterController2D _sender;

	[SerializeField] private Hit _instance;

	private Coroutine _spawnCoroutine;
	private UnityEvent _stopEvent;

	public void SpawnIn(float time, Hit hitPrefub, UnityEvent stopEvent)
	{
		if (NetworkManager.Singleton.IsServer)
		{
			_stopEvent = stopEvent;
			stopEvent.AddListener(StopSpawn);
			_spawnCoroutine = StartCoroutine(SpawnCorutine(time, hitPrefub));
		}
	}

	private IEnumerator SpawnCorutine(float time, Hit hitPrefub)
	{
		while (time >0)
		{
			time -= Time.deltaTime;
			yield return null;
		}

		if (hitPrefub != null && _instance == null)
		{
			_instance = Instantiate(hitPrefub, transform).Init(_sender);
		}
	}

	private void StopSpawn()
	{
		if (_spawnCoroutine != null)
		{
			StopCoroutine(_spawnCoroutine);
		}
		_stopEvent.RemoveListener(StopSpawn);
	}
}