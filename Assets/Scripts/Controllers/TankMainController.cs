using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankMainController : MonoBehaviour {
	[SerializeField]
	private MovementController _movementController;
	[SerializeField]
	private Transform _bulletStart;

	[SerializeField]
	private List<FireController> _cannons;
	[SerializeField]
	private int _currentCannonIndex = 0;
	private FireController _currentfireController;


	// Use this for initialization
	void Start () 
	{
		_currentfireController = _cannons [_currentCannonIndex];
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float movementInput = Input.GetAxis ("Vertical");
		float turnInput = Input.GetAxis ("Horizontal");

		_movementController.Move (movementInput);
		_movementController.Turn (turnInput);
	
		if (FirePressed()) 
		{
			_currentfireController.FireFromPoint (_bulletStart.position);
		}

		if (PrevCannonPressed()) 
		{
			_cannons [_currentCannonIndex].gameObject.SetActive (false);
			_currentCannonIndex--;
			UpdateCannon ();
		}

		if (NextCannonPressed()) 
		{
			_cannons [_currentCannonIndex].gameObject.SetActive (false);
			_currentCannonIndex++;
			UpdateCannon ();
		}
	}

	private bool FirePressed()
	{
		return Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Space);
	}

	private bool PrevCannonPressed()
	{
		return Input.GetKeyDown (KeyCode.Q);
	}

	private bool NextCannonPressed()
	{
		return Input.GetKeyDown (KeyCode.W);
	}

	private void UpdateCannon()
	{
		_currentCannonIndex = Mathf.Clamp (_currentCannonIndex, 0, _cannons.Count - 1);
		_cannons [_currentCannonIndex].gameObject.SetActive (true);
		_currentfireController = _cannons [_currentCannonIndex];

	}
		
}
