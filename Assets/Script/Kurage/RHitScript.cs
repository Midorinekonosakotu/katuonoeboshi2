using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ContentSizeFitter;

public class RHitScript : MonoBehaviour
{
    public KurageBody kurageBody;
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

        if (Input.GetKey(KeyCode.UpArrow) && HitPos < 1.2)  //����E�����L�[���������Ə㉺����
        {
            transform.position += new Vector3(0, HitMove);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && HitPos > -4.5)
        {
            transform.position -= new Vector3(0, HitMove);
        }
    }


    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Rock")){
            kurageBody.CollidedRock();
        }
    }

    private void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Rock")){
            kurageBody.ExitedRock();
        }
    }
}
