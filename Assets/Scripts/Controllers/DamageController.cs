using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour 
{
	[SerializeField]
	private int _damage;

	public int Damage { get{ return _damage; }}

}
