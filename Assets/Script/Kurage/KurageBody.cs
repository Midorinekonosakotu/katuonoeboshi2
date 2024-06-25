using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KurageBody : MonoBehaviour
{
    public RockManager rockManager;
    Rigidbody2D rb;
    public bool playerMoving = true;
    private Vector2 moveInput = Vector2.zero;
    // public float defaultSpeed = 1.5f;
    // public float slowSpeed = 0.5f;
    public bool collidingRock = false;
    public bool collidingWave = false;
    private GameObject wave;


    private void Awake(){
        rb = GetComponent<Rigidbody2D>(); 
    }


    // make everything move faster
    public void MoveFaster(){
        Debug.Log("MOVING FASTER");
        rockManager.SetSpeed(2);
    }

    // make everything move normal speed
    public void MoveNormal(){
        Debug.Log("MOVING NORMAL SPEED");
        rockManager.SetSpeed(1);
    }


    public void CollidedRock(){
        Debug.Log("COLLIDING ROCK");
        //moveSpeed = slowSpeed;

        // IF PUSHED SPACE
        collidingRock = true;
        rockManager.PauseOrResume(true);
        collidingWave = false;

        // if colliding wave
        if(wave != null){
            wave.GetComponent<Wave>().MovePastPlayer();
            MoveNormal();
            wave = null;
        }
    }

    public void ExitedRock(){
        Debug.Log("EXITING ROCK");
        //moveSpeed = defaultSpeed;
        collidingRock = false;
        rockManager.PauseOrResume(false);
    }


    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Wave")){
            Debug.Log("COLLIDING WAVE");
            collidingWave = true;
            wave = col.gameObject;
            MoveFaster();
        }
    }
}
