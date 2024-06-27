using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ComboManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI comboText;
    public ScoreManager scoreManager;
    public int combo = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager.ComboCount10 > 0)
        {
            combo = 0;
            combo = scoreManager.ComboCount10;
        }

        if (scoreManager.ComboCount100 > 0)
        {
            combo = 0;
            combo = scoreManager.ComboCount100;
        }
        comboText.text = combo.ToString();
    }
}
