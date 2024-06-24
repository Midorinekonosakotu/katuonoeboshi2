using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTentacles : MonoBehaviour
{
    //�E�G��̓��������̐��l�ݒ�
    [SerializeField] private Vector2 RTentaclesScale;

    //���݂̉E�G��̑傫���L�^�p
    private float RTentaclesY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���݂�y�̑傫����ۑ�
        RTentaclesY = transform.localScale.y;

        //�G������ɐL�΂�
        if (Input.GetKey(KeyCode.DownArrow) && RTentaclesY < 7.3)
        {
            RTentaclesY += RTentaclesScale.y;
        }

        //�G�����ɂ�����
        if (Input.GetKey(KeyCode.UpArrow) && RTentaclesY > 1)
        {
            RTentaclesY -= RTentaclesScale.y;
        }

        //�V���Ȓl��������
        transform.localScale = new Vector2(1, RTentaclesY);
    }
}
