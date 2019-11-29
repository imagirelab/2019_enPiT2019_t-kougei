using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeReset : MonoBehaviour
{
    public LifePoint LPtext;
    InputField inputField;
    public int NewLP = 0;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
        InitInputField();
    }

    // Update is called once per frame
    public void SetLife()
    {
        if (int.TryParse(inputField.text, out NewLP))
        {
            LPtext.SetLP(NewLP);
        }
        else
        {
            Debug.Log("int.TryParse(inputField.text, out NewLP) is failed!");
        }

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
