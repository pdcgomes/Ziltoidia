using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
	public float spawnStartDelay = 3f;
	public float spawnInterval = 5f;
    public int maximumNumberOfLivingEntities = 10;
    
	public GameObject[] enemies;
    
    protected List<GameObject> spawnedEntities = new List<GameObject>();
	
    void Awake()
    {
    }
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
        bool canSpawn = (spawnedEntities.Count < maximumNumberOfLivingEntities);
        if(canSpawn == false) {
            return;
        }
        
		int index = Random.Range(0, enemies.Length);
		
        // Fixme: ensure we spawn at a position where we won't collide with anything (pdcgomes 31.12.2013)
        Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-10f, 10f), 
                                            transform.position.y + Random.Range(-10f, 10f), 
                                            transform.position.z);
        
        GameObject spawnedEntity = (GameObject)Instantiate(enemies [index], spawnPosition, transform.rotation);
        spawnedEntity.GetComponent<ShipDamageControl>().OnShipDestroyed += OnSpawnedEntityDestroyed;
        spawnedEntities.Add(spawnedEntity);
	}
    
    void OnSpawnedEntityDestroyed(GameObject entity)
    {
        spawnedEntities.Remove(entity);
    }
}
