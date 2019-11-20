using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplayLife : MonoBehaviour
{
    public StartLifeController inputManager;

    public float playerLife;
    static PlayerDisplayLife instance;

    public Text lifeText;

    public static PlayerDisplayLife Instance
    {
        get { return instance; }
    }

    void Update()
    {
        instance = this;
    }

    public void changeLife()
    {
        playerLife = inputManager.startLife;
        lifeText.text = playerLife.ToString();
    }
}