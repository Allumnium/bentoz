using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene_game : MonoBehaviour
{

    public void pressPlay()
    {
        SceneManager.LoadScene("game");
    }
}
