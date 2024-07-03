using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RangeJFish : MonoBehaviour
{
    ScoreManager scoreManager;
    public RectTransform JFish;
    private float move = 0.0005f;
    [SerializeField] int counter = 10400;
    public bool countStop = false;
    public bool WaveFlag = false;
    public bool RockFlag = false;
    public bool GoalFlag = false;
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
                move = 0.001f;
                counter -= 2;
            }
        }
        else if (WaveFlag == false)
        {
            if (countStop == false)
            {
                move = 0.0005f;
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
            GoalFlag = true;
            move = 0f;
        }
    }
}
