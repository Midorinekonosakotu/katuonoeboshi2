using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RangeJFish : MonoBehaviour
{
    ScoreManager scoreManager;
    public RectTransform JFish;
    private float move;
    [SerializeField] float counter = 60;
    private float nowCount;
    public bool countStop = false;
    public bool WaveFlag = false;
    public bool RockFlag = false;
    public bool GoalFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        nowCount = counter;
    }

    // Update is called once per frame
    void Update()
    {
        //JFish.position += new Vector3(-move, 0, 0);

        if (WaveFlag == true)
        {
            if (countStop == false)
            {
                move = 1.2f;
            }
        }
        else if (WaveFlag == false)
        {
            if (countStop == false)
            {
                move = 1.0f;
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

        GameCountDown(move);

        if (nowCount < 0)
        {
            GoalFlag = true;
            move = 0f;

            GetRanking();

            SetRanking(ScoreManager.score);
        }
    }

    private void GameCountDown(float _speed)
    {
        nowCount -= Time.deltaTime * _speed;

        float gamePercent = nowCount / counter;

        float JFishPos = 2.8f + 5.4f * gamePercent;

        JFish.position = new Vector3(JFishPos, JFish.position.y);
    }

    string[] Ranking = RankingManagerScript.ranking;
    int[] rankingValue = new int[5];    //歴代スコア保存の箱
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < Ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(RankingManagerScript.ranking[i], 0);
        }
    }

    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < rankingValue.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }
        //入れ替えた値を保存
        for (int i = 0; i < Ranking.Length; i++)
        {
            PlayerPrefs.SetInt(RankingManagerScript.ranking[i], rankingValue[i]);
        }
        PlayerPrefs.Save();
    }
}
