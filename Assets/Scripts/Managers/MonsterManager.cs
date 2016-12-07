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
		monster.MonsterManager = this;

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
		print (" B "+border);

		if (border > 0) 
		{
			return new Vector3 (-18, 0, Random.Range (-20, 10));
		} 
		else 
		{
			return new Vector3 (18, 0, Random.Range (-20, 10));
		}


	}
		
}
