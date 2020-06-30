using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour
{
    private PlayerAttributes attr;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //search for the local player
        if (attr == null)
        {
            GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject g in p)
            {
                if (g.GetComponent<Mirror.NetworkIdentity>().isLocalPlayer)
                {
                    Debug.Log("FOUND LOCAL PLAYER");
                    attr = g.GetComponent<PlayerAttributes>();
                }

            }
        }
        else
        {
            GetComponent<Text>().text = attr.Points.ToString();
        }
    }
}
