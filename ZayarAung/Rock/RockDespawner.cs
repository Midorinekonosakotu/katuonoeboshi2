using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDespawner : MonoBehaviour
{
    BoxCollider2D col;
    public RockManager rockManager;

    private void Awake(){
        col = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Rock")){
            //Debug.Log("DESTROYING ROCK");
            rockManager.RemoveRock(col.gameObject);
            //Destroy(col.gameObject);
        }
    }
}
