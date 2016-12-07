using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	[SerializeField]
	private MovementController _movementController;
	[SerializeField]
	private HealthController _healthController;
	[SerializeField]
	private DamageController _damageController;

	private Transform _playerTransform;

	private const float DEF_INPUT = 1;

	public Transform PlayerTransform { set { _playerTransform = value; }}

	void Update () 
	{
		//calculate is target on the left or on the right side of monster
		Vector3 relative = transform.InverseTransformPoint(_playerTransform.position);
		float angle = Mathf.Atan2(relative.x, relative.z);

		float input = angle > 0 ? 1 : -1;

		//_movementController.Turn (input);
		//_movementController.Move (DEF_INPUT);
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Tank") 
		{
			OnTankCollide (other);
		} 
		else if (other.transform.tag == "Bullet") 
		{
			OnBulletCollide (other);
		}
	}

	private void OnTankCollide(Collider tank)
	{
		HealthController health = tank.GetComponent<HealthController> ();

		if (health != null)
			health.MakeDamage (_damageController.Damage);

		Destroy (gameObject);
	}

	private void OnBulletCollide(Collider bullet)
	{
		DamageController damageController = bullet.GetComponent<DamageController> ();

		if (bullet != null)
			_healthController.MakeDamage (damageController.Damage);

		SimplePool.BackToPool (bullet.gameObject);
	}
}
