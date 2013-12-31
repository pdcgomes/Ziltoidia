using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public float spawnStartDelay = 3f;
	public float spawnInterval = 5f;

	public GameObject[] enemies;
	
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("SpawnRandomEnemy", spawnStartDelay, spawnInterval);
	}

	// Update is called once per frame
	void Update()
	{

	}
	
	void SpawnRandomEnemy()
	{
		int index = Random.Range(0, enemies.Length);
		Instantiate(enemies [index], transform.position, transform.rotation);
	}
}
