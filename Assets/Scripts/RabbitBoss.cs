using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBoss : MonoBehaviour
{
    public CharacterController2D player;
    public Transform[] telportLocations;
    public bool teleportCountdownStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        Telport();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(player.transform.position, transform.position) < 12 && !teleportCountdownStarted)
        {
            teleportCountdownStarted = true;
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
        bool isNewLocation;
        
        do
        {
            newPos = telportLocations[Random.Range(0, telportLocations.Length)];
            if (newPos.position == transform.position)
                isNewLocation = false;
            else
                isNewLocation = true;
        
        } while (!isNewLocation);

        transform.position = newPos.position;
        teleportCountdownStarted = false;
    }
}
