using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class goend : MonoBehaviour
{
    GameObject gauge;
     private float score; 
    // Start is called before the first frame update
    void Start()
   {
        this.gauge = GameObject.Find("gauge");
    }
    // Update is called once per frame  
    void Update()
    {
        if (this.gauge.GetComponent<Image>().fillAmount ==0)
        {
            if (score >= 1000)
            {
                SceneManager.LoadScene("end_succes", LoadSceneMode.Single);
            }
            else if (score <= 1000)
            {
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
