using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexEffect : MonoBehaviour
{
    public float startPos;
    private Vector3 dummyPos;
    public float spriteLength;
    public float parallexAmount;
    public float parallexAmountNormal;
    public float parallexAmountFast;
    public bool moving = true;


    // Start is called before the first frame update
    void Start()
    {
        //startPos = transform.position.x;
        dummyPos = transform.position;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
        parallexAmount = parallexAmountNormal;
    }

    // Update is called once per frame
    void Update()
    {
        if(moving){
            float delta = parallexAmount * Time.deltaTime;
            transform.position += new Vector3(delta, 0f, 0f);

            if(Mathf.Abs(transform.position.x) - (spriteLength/2) > 0){
                transform.position -= new Vector3(spriteLength, 0f, 0f);
                Debug.Log("background reset");
            }
        }
    }
}
