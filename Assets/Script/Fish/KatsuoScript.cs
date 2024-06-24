using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class KatsuoScript : MonoBehaviour
{
    [SerializeField] private float KatsuoSpeed;     //移動速度
    private float KatsuoPosX;   //現在のX座標
    private int LHit = 0;   //左触手が当たっているか
    private int RHit = 0;   //右触手が当たっているか
    private int Movie = 0;
    SpriteRenderer col;
    PolygonCollider2D KatsuoColl;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        KatsuoPosX = transform.position.x;  //現在のX座標

        if ((LHit == 0 || RHit == 0) && Movie == 0)     //クラゲに触れていなければ進む
        {
            transform.position += new Vector3(KatsuoSpeed, 0);

            if (KatsuoPosX > 10)   //画面外に出たらオブジェクトを消去する
            {
                Destroy(gameObject);
            }
        }
        else if (LHit == 1 && RHit == 1)     //どちらの触手も当たっているとき
        {
            Movie = 1;
            StartCoroutine(Blink());        //点滅の処理（下のBlinkを参照）
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //　触手が当たっているかの判定
    {
        if (collision.CompareTag("LHit"))
        {
            LHit = 1;
        }
        if (collision.CompareTag("RHit"))
        {
            RHit = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)　//触手が離れた時の判定
    {
        if (collision.CompareTag("LHit"))
        {
            LHit = 0;
        }
        if (collision.CompareTag("RHit"))
        {
            RHit = 0;
        }
    }

   
    private IEnumerator Blink()     //点滅の処理
    {
        KatsuoColl = gameObject.GetComponent<PolygonCollider2D>();  //当たり判定を消去
        KatsuoColl.enabled = false;
        for (int count = 0;  count < 2; count++) 
        { 

            col.color = new(col.color.r, col.color.g, col.color.b, 0.5f);   //透明度を０にする
            yield return new WaitForSeconds(0.1f);
            col.color = new(col.color.r, col.color.g, col.color.b, 1.0f); //透明度を255にする
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
