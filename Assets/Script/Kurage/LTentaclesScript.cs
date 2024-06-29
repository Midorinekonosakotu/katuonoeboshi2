using UnityEngine;

public class LTentaclesScript : MonoBehaviour
{
    //���G��̓��������̐��l�ݒ�
    [SerializeField] private Vector2 LTentaclesScale;

    //���݂̍��G��̑傫���L�^�p
    private float LTentaclesY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //���݂�y�̑傫����ۑ�
        LTentaclesY = transform.localScale.y;

        //�G������ɐL�΂�
        if (Input.GetKey(KeyCode.S) && LTentaclesY < 7.3)
        {
            LTentaclesY += LTentaclesScale.y;
        }

        //�G�����ɂ�����
        if (Input.GetKey(KeyCode.W) && LTentaclesY > 1)
        {
            LTentaclesY -= LTentaclesScale.y;
        }

        //�V���Ȓl��������
        transform.localScale = new Vector2(1, LTentaclesY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
