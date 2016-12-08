using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
	[SerializeField]
	private int _healthPoints;
	[Range(0,1)]
	[SerializeField]
	private float _armorPoints;

	[SerializeField]
	private Slider _slider;
	[SerializeField]
	private Image _fillImage;
	[SerializeField]
	private Text _armor;

	private int _startHealth;
	private bool firstSet = true;

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
			SetHealthUI ();
		}
	}

	void Start()
	{
		_startHealth = _healthPoints;
		_slider.maxValue = _healthPoints;
		_armor.text = (1 -_armorPoints) * 100 + "%";

		SetHealthUI ();
	}

	public float ArmorPoints { get { return _armorPoints; }}


	public void MakeDamage(int damage)
	{
		float calculatedDamage = damage * _armorPoints;
		HealthPoints -= Mathf.RoundToInt (calculatedDamage);

		if (HealthPoints <= 0)
			MakeDeath ();
			
	}

	public void MakeDeath()
	{
		if (DeathHandler != null)
			DeathHandler (this);

		if (transform.tag == "Tank") 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}

		Destroy (gameObject);
	}

	private void SetHealthUI ()
	{
		_slider.value = HealthPoints;
		_fillImage.color = Color.Lerp (Color.red, Color.green, HealthPoints / _startHealth);
	}
}
