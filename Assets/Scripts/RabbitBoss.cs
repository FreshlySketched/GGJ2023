using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBoss : MonoBehaviour
{
    public CharacterController2D player;
    public Transform[] telportLocations;
    public bool teleportCountdownStarted = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = telportLocations[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(player.transform.position, transform.position) < 12 && teleportCountdownStarted)
        {
            teleportCountdownStarted = false;
            StartCoroutine(TeleportCountdown());

        }


    }

    IEnumerator TeleportCountdown()
    {
        yield return new WaitForSeconds(3f);
        Telport();


    }

    void Telport()
    {
        Transform newPos;

        if()
            Random.Range(0, telportLocations.Length - 1);




    }
}
