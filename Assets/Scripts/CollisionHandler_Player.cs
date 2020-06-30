using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject remains;

    // string OnCollisionEnter(Collision collision)
    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        if (collision.collider.name == "Obst(Clone)")
        {
            Debug.Log("NAME OF THE OBSTACLE ISSSSS");
            Debug.Log("Obst(Clone)");   
            Instantiate(remains, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }

    //If your GameObject keeps colliding with another GameObject with a Collider, do something
    void OnCollisionStay(Collision collision)
    {
        //Check to see if the Collider's name is "Chest"
        if (collision.collider.name == "Obst(Clone)")
        {
            //Output the message
            Debug.Log("Obstacle is here!");

        }
    }
}
