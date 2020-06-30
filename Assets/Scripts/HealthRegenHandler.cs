using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegenHandler : MonoBehaviour
{
    [Range(0,30.0f)]
    public float outofCombatTime;
    [Range(0, 2.0f)]
    public float regenRate;

    private float remainingTime;
    private PlayerAttributes attr;

    private void Start()
    {
        attr = GetComponent<PlayerAttributes>();
        remainingTime = outofCombatTime;
    }

    public void resetHealthRegenTimer()
    {
        Debug.Log("resetting regen timer");
        remainingTime = outofCombatTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log(remainingTime + "\t" + attr.Health + "\t" + attr.MaxHealth);
        if(remainingTime < 0 && attr.Health < attr.MaxHealth)
        {
            if (attr.Health + regenRate > attr.MaxHealth)
                attr.Health = attr.MaxHealth;
            else
                attr.Health += regenRate;

            //Debug.Log("regenerating health!");
        }
        else
        {
            remainingTime -= Time.deltaTime;
        }
    }


}
