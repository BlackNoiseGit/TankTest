using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SimplePool : MonoBehaviour {

	[SerializeField]
	private int _defaultSize;

	[SerializeField]
	private List<PoolItem> _items;

	private static Dictionary<string, List<GameObject>> _pool;
	private static Transform parent;

	void Awake()
	{
		parent = transform;

		if (_pool == null)
			_pool = new Dictionary<string, List<GameObject>> ();

		//fill pool
		foreach (PoolItem item in _items) 
		{
			_pool [item.Key] = new List<GameObject> ();

			for (int i = 0; i <= item.PoolSize - 1; i++) 
			{
				GameObject go = CreateItem (item.Value);
				_pool [item.Key].Add (go);
			}

		}
	}


	public static GameObject GetPooledItem(string item)
	{
		List<GameObject> pooledObjects = null;

		if (_pool.TryGetValue (item, out pooledObjects)) 
		{
			GameObject last = pooledObjects [pooledObjects.Count - 1];

			if (!last.activeInHierarchy) 
			{
				pooledObjects.RemoveAt (pooledObjects.Count - 1);
				pooledObjects.Insert (0, last);
				return last;
			} 
			else 
			{
				pooledObjects.Add (CreateItem (last));
				return pooledObjects [pooledObjects.Count - 1];
			}
		}

		throw new Exception ("No pooled item with name : "+item);
	}

	private static GameObject CreateItem(GameObject prefab)
	{
		GameObject go =  Instantiate (prefab);
		go.name = prefab.name;
		go.transform.SetParent (parent);
		go.SetActive (false);
		return go;
	}


}