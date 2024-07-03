using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score:" + ScoreManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
