using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RangeJFish : MonoBehaviour
{
    ScoreManager scoreManager;
    public RectTransform JFish;
    private float move = 0.0005f;
    [SerializeField] int counter = 10400;
    public bool countStop = false;
    public bool WaveFlag = false;
    public bool RockFlag = false;
    public bool GoalFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JFish.position += new Vector3(-move, 0, 0);

        if (WaveFlag == true)
        {
            if (countStop == false)
            {
                move = 0.001f;
                counter -= 2;
            }
        }
        else if (WaveFlag == false)
        {
            if (countStop == false)
            {
                move = 0.0005f;
                counter--;
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

        if (counter < -1)
        {
            GoalFlag = true;
            move = 0f;

            GetRanking();

            SetRanking(ScoreManager.score);
        }
    }

    string[] Ranking = RankingManagerScript.ranking;
    int[] rankingValue = new int[5];    //���X�R�A�ۑ��̔�
    void GetRanking()
    {
        //�����L���O�Ăяo��
        for (int i = 0; i < Ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(RankingManagerScript.ranking[i], 0);
        }
    }

    void SetRanking(int _value)
    {
        //�������ݗp
        for (int i = 0; i < rankingValue.Length; i++)
        {
            //�擾�����l��Ranking�̒l���r���ē���ւ�
            if (_value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }
        //����ւ����l��ۑ�
        for (int i = 0; i < Ranking.Length; i++)
        {
            PlayerPrefs.SetInt(RankingManagerScript.ranking[i], rankingValue[i]);
        }
        PlayerPrefs.Save();
    }
}
