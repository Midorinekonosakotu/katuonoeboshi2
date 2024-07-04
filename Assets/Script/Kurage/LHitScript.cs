using UnityEngine;

public class LHitScript : MonoBehaviour
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

        if (Input.GetKey(KeyCode.W) && HitPos < 1.2)    //Wキーを押されると上がる
        {
            transform.position += new Vector3(0, HitMove * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && HitPos > -4.5)   //Sキーを押されると下がる
        {
            transform.position -= new Vector3(0, HitMove * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fish10") && kurageBody.canCatchFish) // Fish10タグのついているオブジェクトに触れたとき
        {
            Debug.Log("LFishOK");
            scoreManager.AddScore10();
        }
        if (col.gameObject.CompareTag("Rock")){
            kurageBody.CollidedRock();
        }
    }

    private void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.CompareTag("Fish100") && kurageBody.canCatchFish){
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
