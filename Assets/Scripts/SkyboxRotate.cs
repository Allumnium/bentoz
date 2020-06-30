using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{

    [Range (-2,2)]
    public float speedMultiplier;

    // Update is called once per frame
    void Update()
    {
            //Sets the float value of "_Rotation", adjust it by Time.time and a multiplier.
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * speedMultiplier);
    }
}
