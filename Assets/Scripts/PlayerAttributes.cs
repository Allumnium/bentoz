using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{

    public int MaxHealth = 200 ;
    [Range(0, 200)]
    public float Health;
    public int Points;
    public bool Alive;

    public HealthBar HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        Alive = true;
        Health = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            Debug.Log("CHAR EXPLODE");
            Alive = false;
        	// Destroy(gameObject);
        }
    }
}
