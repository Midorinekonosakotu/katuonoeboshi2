using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goend : MonoBehaviour
{
     private float step_time; 
    // Start is called before the first frame update
    void Start()
   {
     step_time = 0.0f;
   }
    public void Decresegaji()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
      step_time += Time.deltaTime; 
    if (step_time >= 90.0f)  
     {
     SceneManager.LoadScene("end", LoadSceneMode.Single); 
     }
    }
public static int Score()
    {
        return Score;
    }

}
