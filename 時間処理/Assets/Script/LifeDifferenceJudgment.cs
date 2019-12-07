using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDifferenceJudgment : MonoBehaviour
{
    public LifePoint LP1;
    public LifePoint LP2;

    public Text lifeDeffText;

    private int lifeDiff;


    public void LifeDiffJudge()
    {
        lifeDiff = Mathf.Abs(LP1.life - LP2.life);
        lifeDeffText.text = lifeDiff.ToString();
    }
}
