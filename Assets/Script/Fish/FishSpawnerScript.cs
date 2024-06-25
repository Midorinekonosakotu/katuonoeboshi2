using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FishSpawnerScript : MonoBehaviour
{
    [SerializeField] float KatsuoTime;  //�J�c�I�̏o�����Ԑݒ�
    private float Katsuocount;      //�o���܂ł̎c�莞�ԃJ�E���g
    private float fishHight;    //���̍���
    public GameObject Katsuo;   //�J�c�I�̃I�u�W�F�N�g�w��
    [SerializeField] float FishTime; //���̏o�����Ԑݒ�
    private float Fishcount;    //�o���܂ł̎c�莞�ԃJ�E���g
    private int Fishnum;    //�o�����鋛�̎�ނ̔���
    public GameObject fish1;    //��1�̃I�u�W�F�N�g�w��
    public GameObject fish2;    //��2�̃I�u�W�F�N�g�w��
    public GameObject fish3;    //��3�̃I�u�W�F�N�g�w��


    // Start is called before the first frame update
    void Start()
    {
        Katsuocount = KatsuoTime;   //�o�����Ԃ���
        Fishcount = FishTime;       
    }

    // Update is called once per frame
    void Update()
    {
        Katsuocount -= Time.deltaTime;  //�o���܂ł̎��Ԃ��J�E���g
        Fishcount -= Time.deltaTime;

        if(Fishcount < 0)   //�J�E���g���O�ɂȂ�Ƌ����o��
        {
            fishHight = Random.Range(-3.5f, -0.5f);     //�����������_���Ɍ���
            Fishnum = Random.Range(1, 4);   //���̎�ނ������_���Ɍ���
            if(Fishnum == 1)    //��1���o��
            {
                Instantiate(fish1, new Vector2(-10, fishHight),Quaternion.identity);
                Fishcount = FishTime;
            }
            else if (Fishnum == 2)      //��2���o��
            {
                Instantiate(fish2, new Vector2(-10, fishHight), Quaternion.identity);
                Fishcount = FishTime;
            }
            else if (Fishnum == 3)      //��3���o��
            {
                Instantiate(fish3, new Vector2(-10, fishHight), Quaternion.identity);
                Fishcount = FishTime;
            }
        }
        if(Katsuocount < 0)     //�J�E���g���O�ɂȂ�ƃJ�c�I���o��
        {
            fishHight = Random.Range(-3.5f, -0.5f);
            Instantiate(Katsuo, new Vector2(-10, fishHight), Quaternion.identity);
            Katsuocount = KatsuoTime;
        }
    }

}
