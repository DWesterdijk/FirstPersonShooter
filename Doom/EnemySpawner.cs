using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// The EnemySpawner script will let the enemies spawn
    /// randomly in the map.
    /// </summary>
    public GameObject enemy;
    public Transform spawner;
    int spawnTimer;
    [SerializeField]
    private int maxEnemiesInRoom = 20;
    private GameObject[] enemies;
    Vector3 spawnLocation;
    // Use this for initialization
    void Start()
    {
        spawnLocation = new Vector3(spawner.position.x, spawner.position.y - 10, spawner.position.z);
        spawnTimer = Random.Range(0, 600);
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (spawnTimer >= 600)
        {
            if (enemies.Length < maxEnemiesInRoom)
            {
                Instantiate(enemy, spawnLocation, spawner.rotation);
            }
            spawnTimer = 0;
        }
        else
        {
            spawnTimer += Random.Range(1, 5);
        }
    }
}
