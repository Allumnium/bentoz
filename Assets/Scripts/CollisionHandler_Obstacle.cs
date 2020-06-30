using System.Collections;
using UnityEngine;

public class CollisionHandler_Obstacle : MonoBehaviour
{
    public GameObject remains;
    [Range(1,150)]
    public int damageOnCollision;

    IEnumerator selfDestruct()
    {
        //create the particle system as child of the gem
        var breakParticle = Instantiate(remains, transform.position, transform.rotation);
        breakParticle.transform.SetParent(gameObject.transform);

        //hide the gem object, then destroy it after half a second
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(0.3f);//allow time for the particles and sound to finish
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player hit obstacle!");

            other.GetComponent<HealthRegenHandler>().resetHealthRegenTimer();
            other.GetComponent<PlayerAttributes>().Health = Mathf.Max(0, other.GetComponent<PlayerAttributes>().Health - damageOnCollision);
            
            StartCoroutine(selfDestruct());
        }
    }
   
}
