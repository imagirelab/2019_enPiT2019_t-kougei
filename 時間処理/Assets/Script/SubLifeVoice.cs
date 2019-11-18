using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubLifeVoice : MonoBehaviour
{
    public Julius_Client julius;
    public LifePoint right_pl;
    public LifePoint left_pl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(julius.GetResult()==("���C�t�B"))
        {
            right_pl.Damage(2000);
        }
    }
}
