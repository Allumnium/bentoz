using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleStreaksWithSpeed : MonoBehaviour
{
    public GameObject player;
    public CameraFilterPack_Drawing_Manga_Flash_Color streaker;
    [Range(0, 0.3f)]
    public float intensity;

    // Update is called once per frame
    void Update()
    {
        streaker.Intensity = player.GetComponent<Rigidbody>().velocity.magnitude * intensity;
    }
}
