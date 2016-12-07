using UnityEngine;
using System.Collections;

public class TankMainController : MonoBehaviour {
	[SerializeField]
	private MovementController _movementController;
	[SerializeField]
	private FireController _fireController;
	[SerializeField]
	private Transform _bulletStart;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float movementInput = Input.GetAxis ("Vertical");
		float turnInput = Input.GetAxis ("Horizontal");

		_movementController.Move (movementInput);
		_movementController.Turn (turnInput);
	
		if (Input.GetKeyDown (KeyCode.X)) 
		{
			_fireController.FireFromPoint (_bulletStart.position);
		}
	}
}
