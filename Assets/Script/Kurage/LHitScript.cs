using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LHitScript : MonoBehaviour
{
    public KurageBody kurageBody; 
    public ScoreManager scoreManager;
    [SerializeField] private float HitMove;     //�ړ����x��ݒ�
    private float HitPos;   //���ݒn��ۑ�


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HitPos = transform.position.y;      //���ݒn����

        if (Input.GetKey(KeyCode.W) && HitPos < 1.2)    //W�ES�L�[���������Ə㉺����
        {
            transform.position += new Vector3(0, HitMove);
        }
        else if (Input.GetKey(KeyCode.S) && HitPos > -4.5)
        { 
            transform.position -= new Vector3(0, HitMove);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fish10")) // Fish10タグのついているオブジェクトに触れたとき
        {
            Debug.Log("LFishOK");
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
