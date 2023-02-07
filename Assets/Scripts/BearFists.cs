using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearFists : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Punched()
    {
        var allFists = GetComponentsInChildren<DamageDealer>();

        foreach (DamageDealer dd in allFists)
        {
            dd.enabled = true;
        }
    }


    public void StopPunch()
    {
        var allFists = GetComponentsInChildren<DamageDealer>();

        foreach (DamageDealer dd in allFists)
        {
            dd.enabled = false;
        }
    }
}
