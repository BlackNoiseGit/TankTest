using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour 
{
	[SerializeField]
	private float _flatSpeed;
	[SerializeField]
	private float _turnSpeed;

	private Transform _cachedTransform;

	void Awake()
	{
		_cachedTransform = transform;
	}

	public void Move(float movementInput)
	{
		Vector3 movement = transform.forward * movementInput;// * _flatSpeed * Time.deltaTime;
		//_cachedTransform.Translate (_cachedTransform.position + movement);
		_cachedTransform.position = Vector3.MoveTowards(_cachedTransform.position, _cachedTransform.position + movement, _flatSpeed * Time.deltaTime);
	}

	public void Turn(float turnInput)
	{
		float turn = turnInput * _turnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		_cachedTransform.rotation = _cachedTransform.rotation * turnRotation;
	}

}
