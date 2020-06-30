using System.Collections;
using UnityEngine;

public class CollisionHandler_Gem : MonoBehaviour
{
    public GameObject remains;

    public int scoreValue;
    // Start is called before the first frame update

    IEnumerator gemSelfDestruct()
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
            other.GetComponent<PlayerAttributes>().Points += scoreValue;
            Debug.Log("Player collected gem!");
            StartCoroutine(gemSelfDestruct());
        }
    }
   
}
