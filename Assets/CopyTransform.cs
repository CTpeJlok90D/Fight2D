using UnityEngine;

public class CopyTransform : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private Vector3 _positionOffcet;
	[SerializeField] private Vector3 _rotationOffcet;
	[Header("Position")]
	[SerializeField] private bool _copyPositionX;
	[SerializeField] private bool _copyPositionY;
	[SerializeField] private bool _copyPositionZ;
	[Header("Rotation")]
	[SerializeField] private bool _copyRotationX;
	[SerializeField] private bool _copyRotationY;
	[SerializeField] private bool _copyRotationZ;

	protected void Update()
	{
		Execute();
	}

	private void Execute()
	{
		Vector3 newPostion = new()
		{
			x = _copyPositionX ? _target.position.x : transform.position.x,
			y = _copyPositionY ? _target.position.y : transform.position.y,
			z = _copyPositionZ ? _target.position.z : transform.position.z
		};

		Vector3 newRotation = new()
		{
			x = _copyRotationX ? _target.eulerAngles.x : transform.eulerAngles.x,
			y = _copyRotationY ? _target.eulerAngles.y : transform.eulerAngles.y,
			z = _copyRotationZ ? _target.eulerAngles.z : transform.eulerAngles.z
		};

		transform.position = newPostion + _positionOffcet;
		transform.eulerAngles = newRotation + _rotationOffcet;
	}

	private void OnValidate()
	{
		Execute();
	}
}
