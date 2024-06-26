using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    bool Fish10,Fish100 = false;   // �O��G�������̔���
    public int score;   // �X�R�A�̒l������ϐ�
    [SerializeField] TextMeshProUGUI scoreText;
    public bool LHit,RHit,KatsuoHit = false;

    double Combo1 = 10;      // �R���{���̉��Z�_��������ϐ�
    double Combo2 = 100;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;  // �����X�R�A
    }

    // Update is called once per frame
    void Update()
    {
        if (LHit == true && RHit == true)
        {
            KatsuoHit = true;
        }
        // �X�R�A�\��
        scoreText.text = "Score:" + score.ToString() + "/9999";
    }


    public void AddScore10()
    {
        if (Fish10 == false)
        {
            // �X�R�A���Z
            score += 10;
            Fish10 = true;
        }
        else if (Fish10 == true)
        {
            Combo1 = Combo1 + (10 * 0.1);
            score += (int)Combo1;
            Fish100 = false;
            Combo2 = 100;
        }
    }

    public void AddScore100()
    {
        Debug.Log("1");
        if (Fish100 == false)
        {
            // �X�R�A���Z
            score += 100;
            Fish100 = true;
        }
        else if (Fish100 == true)
        {
            Combo2 = Combo2 + (100 * 0.1);
            score += (int)Combo2;
            Fish10 = false;
            Combo1 = 10;
        }
    }
}
