using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Vector3 spawnPosition;
    public GameObject Enemy;
    public int spawnTime;
    private float lastSpawnTime;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastSpawnTime + spawnTime<=Time.time) 
        {
            lastSpawnTime += Time.time;
            var spawneddEnemy = Instantiate(Enemy);
            spawneddEnemy.GetComponent<Enemy>().target = player;
            
        }
    }
}
