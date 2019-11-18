using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1DisplayLife : MonoBehaviour
{
    public Player1InputManager inputManager;

    public float playerLife;
    static Player1DisplayLife instance;

    public Text lifeText;

    public static Player1DisplayLife Instance
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