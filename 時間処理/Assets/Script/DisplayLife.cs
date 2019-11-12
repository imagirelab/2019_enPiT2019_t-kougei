using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLife : MonoBehaviour
{
    public InputManager inputManager;

    public float playerLife;
    static DisplayLife instance;

    public Text lifeText;

    public static DisplayLife Instance
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