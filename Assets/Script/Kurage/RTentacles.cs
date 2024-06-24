using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTentacles : MonoBehaviour
{
    //‰EGè‚Ì“®‚­‘¬‚³‚Ì”’lİ’è
    [SerializeField] private Vector2 RTentaclesScale;

    //Œ»İ‚Ì‰EGè‚Ì‘å‚«‚³‹L˜^—p
    private float RTentaclesY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Œ»İ‚Ìy‚Ì‘å‚«‚³‚ğ•Û‘¶
        RTentaclesY = transform.localScale.y;

        //Gè‚ğ‰º‚ÉL‚Î‚·
        if (Input.GetKey(KeyCode.DownArrow) && RTentaclesY < 7.3)
        {
            RTentaclesY += RTentaclesScale.y;
        }

        //Gè‚ğã‚É‚ ‚°‚é
        if (Input.GetKey(KeyCode.UpArrow) && RTentaclesY > 1)
        {
            RTentaclesY -= RTentaclesScale.y;
        }

        //V‚½‚È’l‚ğ‘ã“ü‚·‚é
        transform.localScale = new Vector2(1, RTentaclesY);
    }
}
