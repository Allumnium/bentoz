using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionHandler : MonoBehaviour
{

    public HealthBar HealthBar;
    public Text Score;
    PlayerAttributes attrs;
    HealthRegenHandler hpHandler;

    private void Start()
    {
        attrs = gameObject.GetComponent<PlayerAttributes>();
        hpHandler = gameObject.GetComponent<HealthRegenHandler>();
    }


    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        Debug.Log("palyer collision!");
        if (collision.collider.name == "Obst(Clone)")
        {
            Debug.Log("Hit Obst!");
            attrs.Health -= 50;
            hpHandler.resetHealthRegenTimer();

        }

        else if (collision.collider.name == "GemPurple(Clone)")
        {
            Debug.Log("Hit Gem!");
            PlayerAttributes attrs = gameObject.GetComponent<PlayerAttributes>();
            attrs.Points += 10;
            Score.text = attrs.Points.ToString();
        }
    }
}
