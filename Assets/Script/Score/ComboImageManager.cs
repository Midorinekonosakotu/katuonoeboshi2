using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboImageManager : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    public ComboManager comboManager;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (comboManager.combo <= 9)   // ƒRƒ“ƒ{‚ª10ˆÈ‰º‚ÌŽž
        {
            image.enabled = false;
        }
        else if (comboManager.combo >= 10 && comboManager.combo <= 29)
        {
            image.enabled = true;
            image.sprite = sprite1;
        }
        else if (comboManager.combo >= 30)
        {
            image.sprite = sprite2;
        }
    }
}
