using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBoss : MonoBehaviour
{
    public CharacterController2D player;
    public Transform[] telportLocations;
    public bool teleportCountdownStarted = false;
    public bool startShooting = false;
    public float waitTime = 4f;

    private Vector2 startPos;
    public GameObject randomBullet;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Telport();
        StartCoroutine(BulletTime());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(player.transform.position, transform.position) < 12 && !teleportCountdownStarted)
        {
            teleportCountdownStarted = true;
            StartCoroutine(TeleportCountdown());

        }

        if(startShooting)
        {

            startShooting = false;
            ShootRandomly();

            /*if (Random.Range(0, 2) == 0)
            {
                

            }

            else
            {



            }*/
        }
    }

    IEnumerator TeleportCountdown()
    {
        yield return new WaitForSeconds(3f);
        Telport();
    }

    IEnumerator BulletTime()
    {
        yield return new WaitForSeconds(2f);
        startShooting = true;
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

    void ShootRandomly()
    {
        //Do forLoop instead where its instantiated, bullets surround
        
        
        var bulletOne = Instantiate(randomBullet, transform.position, transform.rotation);
        var bulletTwo = Instantiate(randomBullet, transform.position, transform.rotation);
        var bulletThree = Instantiate(randomBullet, transform.position, transform.rotation);

        var xVariance = Random.Range(-5, 5);
        var yVariance = Random.Range(-5, 5);

        if (transform.position.x <= startPos.x && transform.position.y <= startPos.y)
        {

            bulletOne.GetComponent<RandomBullet>().SetMovement(new Vector2(2 + xVariance, 1 + yVariance));
            bulletTwo.GetComponent<RandomBullet>().SetMovement(new Vector2(6 + xVariance, 1 + yVariance));
            bulletThree.GetComponent<RandomBullet>().SetMovement(new Vector2(2 + xVariance, 4 + yVariance));
        }

        else if (transform.position.x > startPos.x && transform.position.y <= startPos.y)
        {
            bulletOne.GetComponent<RandomBullet>().SetMovement(new Vector2(-2 + xVariance, 1 + yVariance));
            bulletTwo.GetComponent<RandomBullet>().SetMovement(new Vector2(-6 + xVariance, 1 + yVariance));
            bulletThree.GetComponent<RandomBullet>().SetMovement(new Vector2(-2 + xVariance, 4 + yVariance));

        }

        else if (transform.position.x <= startPos.x && transform.position.y > startPos.y)
        {
            bulletOne.GetComponent<RandomBullet>().SetMovement(new Vector2(2 + xVariance, -2 + yVariance));
            bulletTwo.GetComponent<RandomBullet>().SetMovement(new Vector2(6 + xVariance, -2 + yVariance));
            bulletThree.GetComponent<RandomBullet>().SetMovement(new Vector2(2 + xVariance, -6 + yVariance));

        }


        else
        {
            bulletOne.GetComponent<RandomBullet>().SetMovement(new Vector2(-2 + xVariance, -2 + yVariance));
            bulletTwo.GetComponent<RandomBullet>().SetMovement(new Vector2(-6 + xVariance, -2 + yVariance));
            bulletThree.GetComponent<RandomBullet>().SetMovement(new Vector2(-2 + xVariance, -6 + yVariance));

        }

        StartCoroutine(BulletTime());
    }

}
