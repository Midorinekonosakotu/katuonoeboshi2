using UnityEngine;

public class RHitScript : MonoBehaviour
{
    public KurageBody kurageBody;
    public ScoreManager scoreManager;
    [SerializeField] private float HitMove;     //動く速さ指定
    private float HitPos;   //現在のy座標把握用


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HitPos = transform.position.y;      //現在のy座標

        if (Input.GetKey(KeyCode.UpArrow) && HitPos < 1.2)  //上矢印キーを押されると上がる
        {
            transform.position += new Vector3(0, HitMove * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) && HitPos > -4.5)   //下矢印キーを押されると下がる
        {
            transform.position -= new Vector3(0, HitMove * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fish10") // Fish10タグのついているオブジェクトに触れたとき
        {
            Debug.Log("RFishOK");
            scoreManager.AddScore10();
        }
        if (col.gameObject.CompareTag("Rock")){
            kurageBody.CollidedRock();
        }
    }

    private void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.CompareTag("Fish100")){
            if(col.gameObject.GetComponent<KatsuoScript>().canAddScore && !col.gameObject.GetComponent<KatsuoScript>().scoreAdded){
                Debug.Log("can add");
                scoreManager.AddScore100();
                col.gameObject.GetComponent<KatsuoScript>().scoreAdded = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Rock")){
            kurageBody.ExitedRock();
        }
    }
}
