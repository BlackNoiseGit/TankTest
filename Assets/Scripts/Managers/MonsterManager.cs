using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterManager : MonoBehaviour 
{
	[SerializeField]
	private int _monstersValue = 10;

	[SerializeField]
	private Transform _playerTransform;

	[SerializeField]
	private List<MonsterController> _monstersPrefabs;


	private const int BORDER_X = 18;
	private const int BORDER_Z_MIN = -20;
	private const int BORDER_Z_MAX = 10;

	void Start () 
	{
		for (int i = 0; i <= _monstersValue - 1; i++) 
		{
			CreateMonster ();
		}
	
	}

	private void CreateMonster()
	{
		MonsterController monster = Instantiate (_monstersPrefabs [Random.Range (0, _monstersPrefabs.Count)]);
		monster.PlayerTransform = _playerTransform;

		HealthController healthController = monster.gameObject.GetComponent<HealthController> ();
		monster.gameObject.transform.position = GetRandomPosition ();

		if (healthController != null) 
		{
			healthController.DeathHandler += OnMonsterDeath;
		}
	}

	public void OnMonsterDeath(HealthController healthController)
	{
		healthController.DeathHandler -= OnMonsterDeath;
		CreateMonster ();
	}
		
	private Vector3 GetRandomPosition()
	{
		float border = Random.Range (-1.0f, 1.0f);

		if (border > 0) 
		{
			return new Vector3 (-BORDER_X, 0, Random.Range (BORDER_Z_MIN, BORDER_Z_MAX));
		} 
		else 
		{
			return new Vector3 (BORDER_X, 0, Random.Range (BORDER_Z_MIN, BORDER_Z_MAX));
		}


	}
		
}
