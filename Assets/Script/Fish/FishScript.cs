using System.Collections;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    [SerializeField] float FishSpeed;  //魚の速さ
    private int fishHit = 0;    //当たったかの確認
    private float fishPosX;     //現在のx座標
    private SpriteRenderer col;     //SpriteRendererの数値を扱う箱
    private PolygonCollider2D FishColl;     //PolygonCollider2Dの設定を扱う箱

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SpriteRenderer>();       //SpriteRendererの数値を取得
    }


    // Update is called once per frame
    void Update()
    {
        fishPosX = transform.position.x;    //現在のx座標を保存

        if (fishHit == 0)       //魚が当たっていなければ進む
        {
            transform.position += new Vector3(FishSpeed * Time.deltaTime, 0.0f);
            if (fishPosX > 10)
                Destroy(gameObject);
        }
        else if (fishHit == 1)      //魚が当たったら点滅して消える
        {
            fishHit = 2;    //繰り返さないために値変更
            StartCoroutine(Blink());    //点滅のプログラム（下参照）
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     //触手が当たったかの判定
    {
        if (collision.CompareTag("RHit") || collision.CompareTag("LHit"))
        {
            fishHit = 1;
        }
    }

    private IEnumerator Blink()     //点滅の処理
    {

        for (int count = 0; count < 2; count++)
        {
            FishColl = gameObject.GetComponent<PolygonCollider2D>();    //当たり判定を消去
            FishColl.enabled = false;

            col.color = new(col.color.r, col.color.g, col.color.b, 0.5f);   //透明度を0.5する
            yield return new WaitForSeconds(0.1f);
            col.color = new(col.color.r, col.color.g, col.color.b, 1.0f); //透明度を1にする
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
