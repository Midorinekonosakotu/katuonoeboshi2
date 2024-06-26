using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public bool moving = true;
    public float moveSpeed = 1.5f;
    Rigidbody2D rb;


    private void Awake(){
        rb = GetComponent<Rigidbody2D>(); 
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

        
    private void FixedUpdate(){
        if(moving){
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else{
            rb.velocity = Vector2.zero;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
