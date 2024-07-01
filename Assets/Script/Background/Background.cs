using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public ParallexEffect bgSky;
    public ParallexEffect bgSea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1 = normal, 2 = fast
    public void SetSpeed(int s){
        if(s == 1){
            bgSky.parallexAmount = bgSky.parallexAmountNormal;
            bgSea.parallexAmount = bgSea.parallexAmountNormal;
        }
        else{
            bgSky.parallexAmount = bgSky.parallexAmountFast;
            bgSea.parallexAmount = bgSea.parallexAmountFast;
        }
    }


    public void PauseOrResume(bool pause){
        bgSky.moving = !pause;
        bgSea.moving = !pause;
    }
}
