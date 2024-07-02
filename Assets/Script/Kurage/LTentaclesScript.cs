using UnityEngine;

public class LTentaclesScript : MonoBehaviour
{
    //左触手の動く速さの数値設定
    [SerializeField] private Vector2 LTentaclesScale;

    //現在の左触手の大きさ記録用
    private float LTentaclesY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //現在のyの大きさを保存
        LTentaclesY = transform.localScale.y;

        //触手を下に伸ばす
        if (Input.GetKey(KeyCode.S) && LTentaclesY < 7.3)
        {
            LTentaclesY += LTentaclesScale.y * Time.deltaTime;
        }

        //触手を上にあげる
        if (Input.GetKey(KeyCode.W) && LTentaclesY > 1)
        {
            LTentaclesY -= LTentaclesScale.y * Time.deltaTime;
        }

        //新たな値を代入する
        transform.localScale = new Vector2(1, LTentaclesY);
        
    }
}
