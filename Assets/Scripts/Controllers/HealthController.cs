using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	[SerializeField]
	private int _healthPoints;
	[Range(0,1)]
	[SerializeField]
	private float _armorPoints;

	public event System.Action<HealthController> DeathHandler;

	public int HealthPoints
	{
		get
		{
			return _healthPoints;
		}
		set
		{
			_healthPoints = value;
		}
	}

	public float ArmorPoints { get { return _armorPoints; }}


	public void MakeDamage(int damage)
	{
		print ("HP BEFORE " + HealthPoints);

		float calculatedDamage = damage * _armorPoints;

		HealthPoints -= Mathf.RoundToInt (calculatedDamage);
		print ("HP AFTER " + HealthPoints);
		if (HealthPoints <= 0)
			MakeDeath ();
			
	}

	private void MakeDeath()
	{
		if (DeathHandler != null)
			DeathHandler (this);

		gameObject.SetActive (false);
	}
}
