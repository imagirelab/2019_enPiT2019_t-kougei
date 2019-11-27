using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLifeController : MonoBehaviour
{
    InputField inputField;
    public float  startLife = 8000;

    public float StartLife
    {
        get { return this.startLife; }
        private set { this.startLife = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
        InitInputField();
    }

    // Update is called once per frame
    public void InputLogger()
    {
        float.TryParse(inputField.text, out startLife);

        //startLife = int.Parse(inputValue);
        InitInputField();
    }

    void InitInputField()
    {

        // 値をリセット
        inputField.text = "";

        // フォーカス
        inputField.ActivateInputField();
    }


}
