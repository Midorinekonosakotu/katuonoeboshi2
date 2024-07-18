using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public RockManager rockManager;

    public void SpawnWave(){
        rockManager.SpawnWave();
    }
}
