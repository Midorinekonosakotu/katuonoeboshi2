using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    [SerializeField] float FishSpeed;  //���̑���
    private int fishHit = 0;    //�����������̊m�F
    private float fishPosX;     //���݂�x���W
    private SpriteRenderer col;     //SpriteRenderer�̐��l��������
    private PolygonCollider2D FishColl;     //PolygonCollider2D�̐ݒ��������

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<SpriteRenderer>();       //SpriteRenderer�̐��l���擾
    }

    // Update is called once per frame
    void Update()
    {
        fishPosX = transform.position.x;    //���݂�x���W��ۑ�

        if (fishHit == 0)       //�����������Ă��Ȃ���ΐi��
        {
            transform.position += new Vector3(FishSpeed, 0);
            if(fishPosX > 10)
                Destroy(gameObject);
        }
        else if (fishHit == 1)      //��������������_�ł��ď�����
        {
            fishHit = 2;    //�J��Ԃ��Ȃ����߂ɒl�ύX
            StartCoroutine(Blink());    //�_�ł̃v���O�����i���Q�Ɓj
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     //�G�肪�����������̔���
    {
        if (collision.CompareTag("RHit") || collision.CompareTag("LHit"))
        {
            fishHit = 1;
        }
    }

    private IEnumerator Blink()     //�_�ł̏���
    {

        for (int count = 0; count < 2; count++)
        {
            FishColl = gameObject.GetComponent<PolygonCollider2D>();    //�����蔻�������
            FishColl.enabled = false;

            col.color = new(col.color.r, col.color.g, col.color.b, 0.5f);   //�����x���O�ɂ���
            yield return new WaitForSeconds(0.1f);
            col.color = new(col.color.r, col.color.g, col.color.b, 1.0f); //�����x��255�ɂ���
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(gameObject);
    }
}
