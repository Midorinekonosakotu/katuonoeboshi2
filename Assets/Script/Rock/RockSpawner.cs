using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rock;
    public RockManager rockManager;
    public bool spawningRocks = false;
    private bool spawned = false;
    public float minSpawnTime = 4f;
    public float maxSpawnTime = 10f;
    public float nextSpawnTime = 4f;
    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawningRocks){
            if(spawned){
                nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                spawned = false;
            }
            else{
                if(spawnTimer < nextSpawnTime){
                    spawnTimer += Time.deltaTime;
                }
                else{
                    GameObject r = Instantiate(rock, transform.position, transform.rotation);
                    rockManager.AddRock(r);
                    r.GetComponent<Rock>().moveSpeed = rockManager.currentSpeed;
                    spawnTimer = 0;
                    spawned = true;
                }
            }
        }
    }
}
