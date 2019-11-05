using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLife : MonoBehaviour
{
    public InputManager inputManager;
    public Text lifeText;
    private int playerLife;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerLife = inputManager.StartLife;
        lifeText.text = "LIFE : " + playerLife.ToString();

        if(Input.GetKey(KeyCode.DownArrow))
        {
            playerLife -= 1;
        }
    }
}