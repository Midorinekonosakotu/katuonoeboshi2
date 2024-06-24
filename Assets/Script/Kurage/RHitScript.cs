using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ContentSizeFitter;

public class RHitScript : MonoBehaviour
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

        if (Input.GetKey(KeyCode.UpArrow) && HitPos < 1.2)  //上矢印・下矢印キーが押されると上下する
        {
            transform.position += new Vector3(0, HitMove);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && HitPos > -4.5)
        {
            transform.position -= new Vector3(0, HitMove);
        }
    }
}
