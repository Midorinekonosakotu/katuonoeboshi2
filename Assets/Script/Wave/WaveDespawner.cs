using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Wave")){
            //Debug.Log("DESTROYING WAVE");
            Destroy(col.gameObject);
        }
    }
}
