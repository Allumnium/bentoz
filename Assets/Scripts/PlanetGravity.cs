using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

    
    [Range(-2000,2000)]
    public float gravityStrength;
    public List<GameObject> targets;

    void scanForNewObjects()
    {
        Rigidbody[] Rigidbodies = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
        foreach(Rigidbody rb in Rigidbodies)
        {
            if (!targets.Contains(rb.gameObject))
            {
                targets.Add(rb.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        scanForNewObjects();
        foreach (GameObject g in targets)
        {
            Vector3 gravityUp = (g.transform.position - gameObject.transform.position).normalized;

            g.GetComponent<Rigidbody>().AddForce(gravityUp * gravityStrength);

            //Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }
}
