using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetDuel : MonoBehaviour
{
    public void OnResetDuel()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
