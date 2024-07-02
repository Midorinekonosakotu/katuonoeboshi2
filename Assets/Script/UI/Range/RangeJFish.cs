using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeJFish : MonoBehaviour
{
    public RectTransform JFish;
    private float move = 0.001f;
    [SerializeField] int counter = 5200;
    bool countStop = false;
    public bool WaveFlag = false;
    public bool RockFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JFish.position += new Vector3(-move, 0, 0);

        if (WaveFlag == true)
        {
            if (countStop == false)
            {
                move = 0.002f;
                counter -= 2;
            }
        }
        else if (WaveFlag == false)
        {
            if (countStop == false)
            {
                move = 0.001f;
                counter--;
            }
        }

        if (RockFlag == true)
        {
            move = 0f;
            countStop = true;
        }
        else if (RockFlag == false)
        {
            countStop = false;
        }

        if (counter < -1)
        {
            countStop = true;
            move = 0f;
        }
    }
}
