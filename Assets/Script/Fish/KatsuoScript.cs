using System.Collections;
using UnityEngine;

public class KatsuoScript : MonoBehaviour
{
    [SerializeField] private float KatsuoSpeed;     //カツオのスピード指定
    private float KatsuoPosX;   //カツオのX座標
    public int LHit = 0;   //左触手に当たったか
    public int RHit = 0;   //右触手に当たったか
    private int Movie = 0;
    public bool scoreAdded = false;
    public bool canAddScore = false;
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
        KatsuoPosX = transform.position.x;  //現在のx座標を取得

        if ((LHit == 0 || RHit == 0) && Movie == 0)     //両方の触手に当たっていないとき
        {
            transform.position += new Vector3(KatsuoSpeed * Time.deltaTime, 0.0f);
            if (KatsuoPosX > 10)   //画面外に出たら消去
            {
                Destroy(gameObject);
            }
        }
        else if (LHit == 1 && RHit == 1)     //両方の触手に当たっているとき
        {
            if(!scoreAdded && !canAddScore){
                canAddScore = true;
            }
            else if(scoreAdded){
                KatsuoColl = gameObject.GetComponent<PolygonCollider2D>();  //�����蔻�������
                KatsuoColl.enabled = false;
            }
            Movie = 1;
            StartCoroutine(Blink());        //点滅して消える
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //触手が当たったかの判定
    {
        if (collision.CompareTag("LHit"))
        {
            if(collision.CompareTag("LHit") && collision.GetComponent<LHitScript>().kurageBody.canCatchFish){
                LHit = 1;
            }
        }
        if (collision.CompareTag("RHit"))
        {
            if(collision.CompareTag("RHit") && collision.GetComponent<RHitScript>().kurageBody.canCatchFish){
                RHit = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //触手が離れたかの判定
    {
        if (collision.CompareTag("LHit"))
        {
            if(collision.CompareTag("LHit") && collision.GetComponent<LHitScript>().kurageBody.canCatchFish){
                LHit = 0;
            }
        }
        if (collision.CompareTag("RHit"))
        {
            if(collision.CompareTag("RHit") && collision.GetComponent<RHitScript>().kurageBody.canCatchFish){
                RHit = 0;
            }
        }
    }

   
    private IEnumerator Blink()     //点滅の処理
    {
        for (int count = 0;  count < 2; count++) 
        { 
            col.color = new(col.color.r, col.color.g, col.color.b, 0.5f);   //透明度を0.5にする
            yield return new WaitForSeconds(0.1f);
            col.color = new(col.color.r, col.color.g, col.color.b, 1.0f); //透明度を1にする
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
