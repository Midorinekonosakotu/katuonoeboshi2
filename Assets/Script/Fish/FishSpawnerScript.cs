using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FishSpawnerScript : MonoBehaviour
{
    [SerializeField] float KatsuoTime;  //カツオの出現時間設定
    private float Katsuocount;      //出現までの残り時間カウント
    private float fishHight;    //魚の高さ
    public GameObject Katsuo;   //カツオのオブジェクト指定
    [SerializeField] float FishTime;　//魚の出現時間設定
    private float Fishcount;    //出現までの残り時間カウント
    private int Fishnum;    //出現する魚の種類の判別
    public GameObject fish1;    //魚1のオブジェクト指定
    public GameObject fish2;    //魚2のオブジェクト指定
    public GameObject fish3;    //魚3のオブジェクト指定


    // Start is called before the first frame update
    void Start()
    {
        Katsuocount = KatsuoTime;   //出現時間を代入
        Fishcount = FishTime;       
    }

    // Update is called once per frame
    void Update()
    {
        Katsuocount -= Time.deltaTime;  //出現までの時間をカウント
        Fishcount -= Time.deltaTime;

        if(Fishcount < 0)   //カウントが０になると魚が出現
        {
            fishHight = Random.Range(-3.5f, -0.5f);     //高さをランダムに決定
            Fishnum = Random.Range(1, 4);   //魚の種類をランダムに決定
            if(Fishnum == 1)    //魚1を出す
            {
                Instantiate(fish1, new Vector2(-10, fishHight),Quaternion.identity);
                Fishcount = FishTime;
            }
            else if (Fishnum == 2)      //魚2を出す
            {
                Instantiate(fish2, new Vector2(-10, fishHight), Quaternion.identity);
                Fishcount = FishTime;
            }
            else if (Fishnum == 3)      //魚3を出す
            {
                Instantiate(fish3, new Vector2(-10, fishHight), Quaternion.identity);
                Fishcount = FishTime;
            }
        }
        if(Katsuocount < 0)     //カウントが０になるとカツオが出現
        {
            fishHight = Random.Range(-3.5f, -0.5f);
            Instantiate(Katsuo, new Vector2(-10, fishHight), Quaternion.identity);
            Katsuocount = KatsuoTime;
        }
    }

}
