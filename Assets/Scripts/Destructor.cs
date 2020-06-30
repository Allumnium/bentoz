using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public GameObject remains;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKeyDown("space"))
	    {
	        Instantiate(remains, transform.position, transform.rotation);
	        Destroy(gameObject);
	    }
    }
}
