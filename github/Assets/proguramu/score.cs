using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}public class ScoreGetter
{
    public int GetScore()
    {
        return GameScoreStatic.Score;
    }
}