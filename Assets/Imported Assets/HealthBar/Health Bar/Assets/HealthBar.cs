using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	// public Gradient gradient;
	public Image fill;

    public PlayerAttributes attr;


    public void FixedUpdate()
    {
        //search for the local player
        if(attr == null)
        {
            GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject g in p)
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
            slider.value = attr.Health;
        }

    }

    public void SetMaxHealth(int health)
	{
		slider.maxValue = attr.MaxHealth;
		// fill.color = gradient.Evaluate(1f);
	}




}
