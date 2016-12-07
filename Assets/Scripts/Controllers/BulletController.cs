using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	private Rigidbody _rb;

	[SerializeField]
	private float _speed = 20;

	private Vector3 _direction;

	public Vector3 SetDirection { set { _direction = value; } }

	// Use this for initialization
	void Start () 
	{
		_rb = GetComponent<Rigidbody> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		//Vector3 dir = transform.forward;
		_rb.velocity = _direction * _speed;
	}

}
