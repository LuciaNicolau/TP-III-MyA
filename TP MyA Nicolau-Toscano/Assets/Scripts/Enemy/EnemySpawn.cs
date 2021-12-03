using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn instance;
    public GameObject enemyPatrol;
    public GameObject enemyPatrolShoot;
    public GameObject enemyShoot;

    public List<EnemyWaypoints> enemyType = new List<EnemyWaypoints>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
    }

    private void Start()
    {
        for (int i = 0; i < enemyType.Count; i++)
        {
            //enemyType[i] = Instantiate(enemyType[i].enemyPrefab, enemyType[i].waypoints[0].position, Quaternion.identity);
        }
    }

    [System.Serializable]
    public class EnemyWaypoints
    {
        public string name;
        public GameObject enemyPrefab;
        public List<Transform> waypoints;

    }
}


