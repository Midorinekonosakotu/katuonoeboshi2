using UnityEngine;

public class RTentacles : MonoBehaviour
{
    //右触手の動く速さの数値設定
    [SerializeField] private Vector2 RTentaclesScale;

    //現在の右触手の大きさ記録用
    private float RTentaclesY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //現在のyの大きさを保存
        RTentaclesY = transform.localScale.y;

        //触手を下に伸ばす
        if (Input.GetKey(KeyCode.DownArrow) && RTentaclesY < 7.3)
        {
            RTentaclesY += RTentaclesScale.y * Time.deltaTime;
        }

        //触手を上にあげる
        if (Input.GetKey(KeyCode.UpArrow) && RTentaclesY > 1)
        {
            RTentaclesY -= RTentaclesScale.y * Time.deltaTime;
        }

        //新たな値を代入する
        transform.localScale = new Vector2(1, RTentaclesY);

    }
}
