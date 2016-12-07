using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	[SerializeField]
	private MovementController _movementController;

	public Transform PlayerTransform;

	private const float DEF_INPUT = 1;

	void Update () 
	{
		//calculate is target on the left or on the right side of monster
		Vector3 relative = transform.InverseTransformPoint(PlayerTransform.position);
		float angle = Mathf.Atan2(relative.x, relative.z);

		float input = angle > 0 ? 1 : -1;

		_movementController.Turn (input);
		_movementController.Move (DEF_INPUT);
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Tank") 
		{
			OnTankCollide (other);
		} 
		else if (other.transform.tag == "Bullet") 
		{
			//
		}
	}

	private void OnTankCollide(Collider tank)
	{
		HealthController health = tank.GetComponent<HealthController> ();

		if (health != null)
			health.MakeDamage (55);

		Destroy (gameObject);
	}

	private void OnBulletCollide(Collider bullet)
	{
		//
	}
}
