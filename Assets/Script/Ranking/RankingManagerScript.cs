using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RankingManagerScript : MonoBehaviour
{
    [SerializeField, Header("数値")] //スコアを入れる箱
    public int point;

    string[] ranking = { "No.1", "No.2", "No.3", "No.4", "No.5" }; //順位表示用の箱
    int[] rankingValue = new int[5];    //歴代スコア保存の箱

    [SerializeField,Header("表示させるテキスト")]
    TextMeshProUGUI[] rankingText = new TextMeshProUGUI[5];   //テキストを表示するための箱


    // Start is called before the first frame update
    void Start()
    {
        GetRanking();   //スコアの呼び出し

        SetRanking(point);  //スコアの並べ替えと保存

        for(int i = 0; i < ranking.Length; i++) //テキストに表示する
        {
            rankingText[i].text = ranking[i] + "  " + rankingValue[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i],0);
        }
    }


    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0;i < rankingValue.Length; i++)
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
        for(int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }
        PlayerPrefs.Save();
    }
}
