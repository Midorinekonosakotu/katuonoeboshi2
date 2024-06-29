using UnityEngine;

public class LTentaclesScript : MonoBehaviour
{
    //¶Gè‚Ì“®‚­‘¬‚³‚Ì”’lİ’è
    [SerializeField] private Vector2 LTentaclesScale;

    //Œ»İ‚Ì¶Gè‚Ì‘å‚«‚³‹L˜^—p
    private float LTentaclesY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //Œ»İ‚Ìy‚Ì‘å‚«‚³‚ğ•Û‘¶
        LTentaclesY = transform.localScale.y;

        //Gè‚ğ‰º‚ÉL‚Î‚·
        if (Input.GetKey(KeyCode.S) && LTentaclesY < 7.3)
        {
            LTentaclesY += LTentaclesScale.y;
        }

        //Gè‚ğã‚É‚ ‚°‚é
        if (Input.GetKey(KeyCode.W) && LTentaclesY > 1)
        {
            LTentaclesY -= LTentaclesScale.y;
        }

        //V‚½‚È’l‚ğ‘ã“ü‚·‚é
        transform.localScale = new Vector2(1, LTentaclesY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
