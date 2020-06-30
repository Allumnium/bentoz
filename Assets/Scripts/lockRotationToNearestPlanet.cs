using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockRotationToNearestPlanet : MonoBehaviour
{
    public GameObject nearestPlanet;
    public List<GameObject> planets;
    [Range(1,1000)]
    public float updateDelay_millis;

    public bool runOnce;
    bool isScanning;

    IEnumerator scanForNearbyPlanets() //a new instance of this coroutine thread is called whenever it becomes off of cooldown
    //note that the planets list is passed because the thread can't access the global variable
    {
        isScanning = true;

       

        Rigidbody[] Rigidbodies = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];

        foreach (Rigidbody rb in Rigidbodies)
        {
            if (rb.gameObject.CompareTag("Planet"))
            {
                if(!planets.Contains(rb.gameObject)) planets.Add(rb.gameObject);
                Debug.Log("found planet and added planet to list");
            }
        }

        yield return new WaitForSeconds(updateDelay_millis/1000.0f);
        isScanning = false;
    }

    void FixedUpdate()
    {
        
        //update list of planets
        if (!isScanning) StartCoroutine(scanForNearbyPlanets());//updates periodically

        //find the nearest planet
        float dist = 99999999999.0f;//large for purposes of calculation
        foreach(GameObject g in planets)
        {
            float curDist = Vector3.Distance(g.transform.position, gameObject.transform.position);
            Debug.Log(curDist);
            if (curDist < dist)
            {
                dist = curDist;
                nearestPlanet = g;
            }
        }

        //set rotation of current object so that it is perpendicular to nearest surface
        //source: https://answers.unity.com/questions/1238410/make-object-point-away-from-point-on-sphere.html
        Vector3 sphereNormal = gameObject.transform.position - nearestPlanet.transform.position;
        Vector3 forwardVector = -Vector3.Cross(sphereNormal, transform.right);

        //hard set the rotation
        transform.rotation = Quaternion.LookRotation(forwardVector, sphereNormal);

        if (runOnce) { enabled = false; } //use this to save cpu
    }



}
