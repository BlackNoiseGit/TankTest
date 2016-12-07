using UnityEngine;
using System.Collections;

public class BulltesDisabler : MonoBehaviour 
{
	void OnTriggerExit(Collider other)
	{
		if (other.transform.tag == "Bullet") 
		{
			SimplePool.BackToPool (other.gameObject);
		}
	}
}
