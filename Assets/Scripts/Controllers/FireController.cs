using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour 
{
	[SerializeField]
	private string _bulletPrefabName;

	public void FireFromPoint(Vector3 pos)
	{
		BulletController bc = SimplePool.GetPooledItem (_bulletPrefabName).GetComponent<BulletController> ();
		bc.transform.position = pos;
		bc.gameObject.SetActive (true);

		if (bc != null)
			bc.SetDirection = transform.forward;
	}
}
