using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class RockManager : MonoBehaviour
{

    public RockSpawner rockSpawner;
    public WaveSpawner waveSpawner;
    public Animation Warning;
    AudioSource audioSource;
    public bool rsSpawning {get {return rockSpawner.spawningRocks;}}
    // rock speeds
    public float normalSpeed = 1.5f;
    public float fastSpeed = 3f;
    public float currentSpeed = 1.5f;
    // spawning timer
    public float obstacleTime = 10f;
    private float obstacleTimer = 0f;
    private bool spawning = true;
    public List<GameObject> rocks = new List<GameObject>();
    public List<AudioClip> SFXList = new List<AudioClip>();


    private void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!rsSpawning && spawning){
            if(obstacleTimer < obstacleTime){
                obstacleTimer += Time.deltaTime;
                if(obstacleTimer >= obstacleTime - 0.5f && !audioSource.isPlaying){
                    audioSource.clip = SFXList[0];
                    audioSource.volume = 0.1f;
                    audioSource.Play();
                }
            }
            else{
                Warning.Play();
            }
        }
    }

    public void SpawnWave(){
        StartSpawn();
        waveSpawner.SpawnWave();
        obstacleTimer = 0f;
        obstacleTime = Random.Range(10,20);
        audioSource.Stop();
        audioSource.clip = SFXList[1];
        audioSource.volume = 1f;
        audioSource.Play();
        Debug.Log("Next wave spawn: " + obstacleTime);
    }


    public void AddRock(GameObject rock){
        rocks.Add(rock);
        //Debug.Log("ROCK ADDED TO LIST");
    }

    public void RemoveRock(GameObject rock){
        rocks.Remove(rock);
        Destroy(rock);
        //Debug.Log("ROCK REMOVED FROM LIST");
    }


    // true = pause, false = resume
    public void PauseOrResume(bool pause){
        for(int i = 0; i < rocks.Count; i++){
            rocks[i].GetComponent<Rock>().moving = !pause;
        }
        if(pause){
            StopSpawn();
        }
        spawning = !pause;
    }


    // 1 = normal, 2 = fast
    public void SetSpeed(int s){
        if(s == 1){
            currentSpeed = normalSpeed;
        }
        else{
            currentSpeed = fastSpeed;
        }
        for(int i = 0; i < rocks.Count; i++){
            rocks[i].GetComponent<Rock>().moveSpeed = currentSpeed;
        }
    }


    public void StartSpawn(){
        //Debug.Log("STARTED SPAWNING ROCKS");
        rockSpawner.nextSpawnTime = 0;
        rockSpawner.spawningRocks = true;
    }

    public void StopSpawn(){
        //Debug.Log("STOPPED SPAWNING ROCKS");
        rockSpawner.spawningRocks = false;
        obstacleTimer = 0f;
    }
}
