using UnityEngine;

public class FishSpawnerScript : MonoBehaviour
{
    [SerializeField] float KatsuoTime;  //カツオの出現間隔設定
    private float Katsuocount;      //カツオの出現までのカウント
    private float fishHight;    //魚の高さ指定の箱
    public GameObject Katsuo;   //カツオのオブジェクト指定
    [SerializeField] float FishTime; //魚の出現間隔設定
    private float Fishcount;    //カツオの出現までのカウント
    private int Fishnum;    //魚の種類の判別
    public GameObject fish1;    //魚１のオブジェクト指定
    public GameObject fish2;    //魚２のオブジェクト指定
    public GameObject fish3;    //魚３のオブジェクト指定


    // Start is called before the first frame update
    void Start()
    {
        Katsuocount = KatsuoTime;   //カツオの出現間隔をカウントに代入
        Fishcount = FishTime;       //魚の出現間隔をカウントに代入
    }

    // Update is called once per frame
    void Update()
    {
        Katsuocount -= Time.deltaTime;  //カウントから経過時間を引く
        Fishcount -= Time.deltaTime;

        if(Fishcount < 0)   //カウントが０になったら　
        {
            fishHight = Random.Range(-3.5f, -0.5f);     //高さをランダムに決める
            Fishnum = Random.Range(1, 4);   //魚の種類を決める
            if(Fishnum == 1)    //魚１を出す
            {
                Instantiate(fish1, new Vector2(-10, fishHight),Quaternion.identity);
                Fishcount = FishTime;
            }
            else if (Fishnum == 2)      //魚２を出す
            {
                Instantiate(fish2, new Vector2(-10, fishHight), Quaternion.identity);
                Fishcount = FishTime;
            }
            else if (Fishnum == 3)      //魚３を出す
            {
                Instantiate(fish3, new Vector2(-10, fishHight), Quaternion.identity);
                Fishcount = FishTime;
            }
        }
        if(Katsuocount < 0)     //カツオのカウントが０になったらカツオを出す
        {
            fishHight = Random.Range(-3.5f, -0.5f);
            Instantiate(Katsuo, new Vector2(-10, fishHight), Quaternion.identity);
            Katsuocount = KatsuoTime;
        }
    }

}
