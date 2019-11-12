using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mic_debug : MonoBehaviour
{
    public TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string str)
    {
        text.text = str;
    }
}
