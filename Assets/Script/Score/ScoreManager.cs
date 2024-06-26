using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    bool Fish10,Fish100 = false;   // 前回触った魚の判定
    public int score;   // スコアの値を入れる変数
    [SerializeField] TextMeshProUGUI scoreText;
    public bool LHit,RHit,KatsuoHit = false;

    double Combo1 = 10;      // コンボ時の加算点数を入れる変数
    double Combo2 = 100;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;  // 初期スコア
    }

    // Update is called once per frame
    void Update()
    {
        if (LHit == true && RHit == true)
        {
            KatsuoHit = true;
        }
        // スコア表示
        scoreText.text = "Score:" + score.ToString() + "/9999";
    }


    public void AddScore10()
    {
        if (Fish10 == false)
        {
            // スコア加算
            score += 10;
            Fish10 = true;
        }
        else if (Fish10 == true)
        {
            Combo1 = Combo1 + (10 * 0.1);
            score += (int)Combo1;
            Fish100 = false;
            Combo2 = 100;
        }
    }

    public void AddScore100()
    {
        Debug.Log("1");
        if (Fish100 == false)
        {
            // スコア加算
            score += 100;
            Fish100 = true;
        }
        else if (Fish100 == true)
        {
            Combo2 = Combo2 + (100 * 0.1);
            score += (int)Combo2;
            Fish10 = false;
            Combo1 = 10;
        }
    }
}
