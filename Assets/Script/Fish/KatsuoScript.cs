using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class KatsuoScript : MonoBehaviour
{
    [SerializeField] private float KatsuoSpeed;     //�ړ����x
    private float KatsuoPosX;   //���݂�X���W
    public int LHit = 0;   //���G�肪�������Ă��邩
    public int RHit = 0;   //�E�G�肪�������Ă��邩
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
        KatsuoPosX = transform.position.x;  //���݂�X���W

        if ((LHit == 0 || RHit == 0) && Movie == 0)     //�N���Q�ɐG��Ă��Ȃ���ΐi��
        {
            transform.position += new Vector3(KatsuoSpeed, 0);

            if (KatsuoPosX > 10)   //��ʊO�ɏo����I�u�W�F�N�g����������
            {
                Destroy(gameObject);
            }
        }
        else if (LHit == 1 && RHit == 1)     //�ǂ���̐G����������Ă���Ƃ�
        {
            Movie = 1;
            StartCoroutine(Blink());        //�_�ł̏����i����Blink���Q�Ɓj
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //�@�G�肪�������Ă��邩�̔���
    {
        ScoreManager katsuoHit;
        GameObject obj = GameObject.Find("ScoreManager");
        katsuoHit = obj.GetComponent<ScoreManager>();

        if (collision.CompareTag("LHit"))
        {
            katsuoHit.LHit = true;
            LHit = 1;
        }
        if (collision.CompareTag("RHit"))
        {
            katsuoHit.RHit = true;
            RHit = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //�G�肪���ꂽ���̔���
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

   
    private IEnumerator Blink()     //�_�ł̏���
    {
        KatsuoColl = gameObject.GetComponent<PolygonCollider2D>();  //�����蔻�������
        KatsuoColl.enabled = false;
        for (int count = 0;  count < 2; count++) 
        { 

            col.color = new(col.color.r, col.color.g, col.color.b, 0.5f);   //�����x���O�ɂ���
            yield return new WaitForSeconds(0.1f);
            col.color = new(col.color.r, col.color.g, col.color.b, 1.0f); //�����x��255�ɂ���
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
