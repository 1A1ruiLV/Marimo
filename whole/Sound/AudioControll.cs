using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    static Mu_Vol_Changer prevBGM = null;
    public Mu_Vol_Changer mu_vol;
    void Start()
    {
        if(prevBGM == null)
        {
            prevBGM = mu_vol;
            mu_vol.Play();
        }
        else
        {
            Destroy(mu_vol );
            mu_vol = prevBGM;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
