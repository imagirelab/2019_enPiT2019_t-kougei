using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDifferenceJudgment : MonoBehaviour
{
    public ImpressionVoice impressionVoice;
    public LifePoint LP1;
    public LifePoint LP2;

    public Text lifeDeffText;

    private int lifeDiff;


    public void LifeDiffJudge()
    {
        lifeDiff = Mathf.Abs(LP1.life - LP2.life);
        lifeDeffText.text = lifeDiff.ToString();

        if(lifeDiff <= 8000 && lifeDiff > 6000 )
        {
            impressionVoice.Diff8000();
        }

        else if (lifeDiff <= 6000 && lifeDiff > 4000)
        {
            impressionVoice.Diff6000();
        }

        else if (lifeDiff <= 4000 && lifeDiff > 2000)
        {
            impressionVoice.Diff4000();
        }

        else if (lifeDiff <= 2000 && lifeDiff > 0)
        {
            impressionVoice.Diff2000();
        }
    }
}
