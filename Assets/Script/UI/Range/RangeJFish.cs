using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeJFish : MonoBehaviour
{
    public RectTransform JFish;
    private float move = 0.002f;
    [SerializeField] int counter = 2600;
    bool countStop = false;
    public bool WaveFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JFish.position += new Vector3(-move, 0, 0);

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    WaveFlag = true;
        //}
        
        //if(Input.GetKeyUp(KeyCode.Space))
        //{
        //    WaveFlag = false;
        //}


        if(WaveFlag == true)
        {
            if (countStop == false)
            {
                move = 0.004f;
                counter -= 2;
            }
        }
        else
        {
            if (countStop == false)
            {
                move = 0.002f;
                counter--;
            }
        }

        if (counter < -1)
        {
            countStop = true;
            move = 0f;
        }
    }
}
