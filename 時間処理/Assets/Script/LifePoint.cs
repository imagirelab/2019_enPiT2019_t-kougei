using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour
{
    public Text text;
    
    public int initial_life = 8000;
    int life;
    int view_life; //表示用

    // Start is called before the first frame update
    void Start()
    {
        life = initial_life;
        view_life = life;
        text.text = view_life.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life < view_life)
        {
            view_life -= 25;
            if (view_life < life) view_life = life;// 引きすぎたら戻す
            text.text = view_life.ToString();
        }
        else if(life>view_life)
        {
            view_life += 25;
            if (view_life > life) view_life = life;// 足しすぎたら戻す
            text.text = view_life.ToString();
        }
        if(view_life == 0)
        {
            Debug.Log("ライフが0になりました");
        }
        
    }

    public void Damage(int amount)
    {
        life -= amount;
    }

    public void SetLP(int LP)
    {
        life = LP;   
    }

    public int getLP()
    {
        return life;
    }

    public void zeroLife()
    { 
            text.color = new Color(132f / 255f, 68f / 255f, 205f / 255f);//0になったら
    }
}
