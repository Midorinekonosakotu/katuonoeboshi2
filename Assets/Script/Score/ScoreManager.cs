using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private bool Fish10on,Fish100on = false;   // 前回触った魚の判定
    public int ComboCount10, ComboCount100 = 0;
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
        scoreText.text = "Score:" + score.ToString();
    }


    public void AddScore10()
    {
        if (Fish10on == false)
        {
            // スコア加算
            score += 10;
            Fish10on = true;
            ComboCount10++;
            ComboCount100 = 0;
        }
        else if (Fish10on == true)
        {
            Combo1 = Combo1 + (10 * 0.1);
            score += (int)Combo1;
            Fish100on = false;
            Combo2 = 100;
            ComboCount10++;
        }
    }

    public void AddScore100()
    {
        Debug.Log("1");
        if (Fish100on == false)
        {
            // スコア加算
            score += 100;
            Fish100on = true;
            ComboCount100++;
            ComboCount10 = 0;
        }
        else if (Fish100on == true)
        {
            Combo2 = Combo2 + (100 * 0.1);
            score += (int)Combo2;
            Fish10on = false;
            Combo1 = 10;
            ComboCount100++;
        }
    }
}
