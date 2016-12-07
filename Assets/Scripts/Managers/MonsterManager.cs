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

		HealthController healthController = monster.gameObject.GetComponent<HealthController> ();

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
		

}
