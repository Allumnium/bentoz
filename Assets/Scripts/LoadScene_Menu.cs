using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void pressExitMenuButton()
    {
        SceneManager.LoadScene("menu");
    }
}
