using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject wave;
    
    public void SpawnWave(){
        Instantiate(wave, transform.position, transform.rotation);
    }
}
