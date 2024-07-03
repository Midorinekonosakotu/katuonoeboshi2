using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goend : MonoBehaviour
{
    RangeJFish rangeJFish;
    // Start is called before the first frame update
    void Start()
   {
        rangeJFish = GameObject.Find("RangeJFishMove").GetComponent<RangeJFish>();
    }
    // Update is called once per frame  
    void Update()
    {
        if (rangeJFish.GoalFlag == true)
        {
            if (ScoreManager.score >= 1000)
            {
                Debug.Log("Scene1OK");
                SceneManager.LoadScene("end_succes", LoadSceneMode.Single);
            }
            else if (ScoreManager.score < 1000)
            {
                Debug.Log("Scene2OK");
                SceneManager.LoadScene("end_failure", LoadSceneMode.Single);
            }
        }
    }
}
public static class GameScoreStatic
{
    public static int Score = 0;
}

public class ScoreChanger
{
    public void ScorePlusOne()
    {
        GameScoreStatic.Score++;
    }
}
