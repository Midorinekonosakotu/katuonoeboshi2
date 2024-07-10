using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gocredit : MonoBehaviour
{
    public void SwitchScene()
    {
    SceneManager.LoadScene("credit", LoadSceneMode.Single);
    }
}
