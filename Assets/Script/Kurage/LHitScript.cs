using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHitScript : MonoBehaviour
{
    [SerializeField] private float HitMove;     //移動速度を設定
    private float HitPos;   //現在地を保存


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HitPos = transform.position.y;      //現在地を代入

        if (Input.GetKey(KeyCode.W) && HitPos < 1.2)    //W・Sキーが押されると上下する
        {
            transform.position += new Vector3(0, HitMove);
        }
        else if (Input.GetKey(KeyCode.S) && HitPos > -4.5)
        { 
            transform.position -= new Vector3(0, HitMove);
        }
    }
}
