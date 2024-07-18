using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D col;
    public float moveSpeed = 3f;
    private bool moving = true;
    private bool collidedPlayer = false;
    private float enableTime = 2f;
    private float enableTimer = 0f;


    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }


    private void FixedUpdate(){
        if(moving){
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(collidedPlayer && !col.enabled){
            if(enableTimer < enableTime){
                enableTimer += Time.deltaTime;
            }
            else{
                col.enabled = true;
            }
        }
        
    }


    public void MovePastPlayer(){
        if(collidedPlayer){
            col.enabled = false;
            moving = true;
        }
    }


    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Jellyfish")){
            collidedPlayer = true;
            moving = false;
        }
    }
}
