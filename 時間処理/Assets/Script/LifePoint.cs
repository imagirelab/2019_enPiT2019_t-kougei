using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour
{
    public Text text;
    
    public int life = 8000;
    int before_life;
    int damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        before_life = life;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamage)
        {
            life -= 25;
            text.text = life.ToString();
            isDamage = !(before_life-damage == life);
        }
    }

    bool isDamage { get; set; }

    public void Damage(int amount)
    {
        damage += amount;
        before_life = life;
        isDamage = true;
    }
}
