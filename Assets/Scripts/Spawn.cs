using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    public GameObject obj;
    [Range(0,300)]
    public int objCount;
    

    void Start()
    {
        // Sets the position to be somewhere inside a circle
        // with radius 5 and the center at zero. Note that
        // assigning a Vector2 to a Vector3 is fine - it will
        // just set the X and Y values.

        for (int i = 0; i < objCount; i++) {
    		Vector3 pos = Random.insideUnitSphere.normalized;
    		Transform new_object = Instantiate(obj, pos * 41, Quaternion.identity).transform;
            new_object.parent = gameObject.transform;
    	    // obst.transform.position = pos;
    	}
        
    }

}
