using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{

    public bool isVisible;

    public GameObject menuElement;

    public void toggleMenu()
    {
        isVisible = !isVisible;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            toggleMenu();
        }
        menuElement.gameObject.active = isVisible;


    }
}
