using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2DisplayLife : MonoBehaviour
{
    public Player2InputManager inputManager;

    public float playerLife;
    static Player2DisplayLife instance;

    public Text lifeText;

    public static Player2DisplayLife Instance
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