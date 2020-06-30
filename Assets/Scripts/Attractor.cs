using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    // const float G = 667.4f;

    // public static List<Attractor> Attractors;

    public Rigidbody rb;

    void FixedUpdate ()
    {
    	Attractor[] attractors = FindObjectsOfType<Attractor>();
    	foreach (Attractor attractor in attractors)
    	{
    		if (attractor != this)
    		    Attract(attractor);	
    	}
    }

 //    void onEnable () 
 //    {
 //    	if (Attractors == null)
 //    		Attractors = new List<Attractor>();

 //    	Attractors.Add(this);
 //    }


	// void onDisable () 
 //    {
 //    	Attractors.Remove(this);
 //    }
    


	void Attract (Attractor objToAttract)
	{
		Rigidbody rbToAttract = objToAttract.rb;
		Vector3 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;

		if (distance == 0f)
			return;

		float forceMagnitude = (rb.mass * rbToAttract.mass / Mathf.Pow(distance, 2));
		Vector3 force = direction.normalized * forceMagnitude;

		rbToAttract.AddForce(force);
	}
}
