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

    public int amountOfBullets = 15;
    public float distanceFromEnemy = 10f;

    public float enemyDamage;
    public bool allowTeleport = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Telport();
        StartCoroutine(BulletTime());
        enemyDamage = GetComponent<DamageDealer>().m_health;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(player.transform.position, transform.position) < distanceFromEnemy && !teleportCountdownStarted)
        {
            teleportCountdownStarted = true;
            StartCoroutine(TeleportCountdown());

        }

        if(startShooting)
        {
            startShooting = false;

            if (Random.Range(0, 4) > 0 && !teleportCountdownStarted)
            {
                
                ShootRandomly();

            }

            else if (!teleportCountdownStarted)
            {

            }
        }

        if (GetComponent<DamageDealer>().m_health < enemyDamage)
        {
            Telport();
            allowTeleport = false;
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
        if (allowTeleport)
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
            startShooting = true;
            allowTeleport = true;
        }
    }

    void ShootRandomly()
    {
        //Do forLoop instead where its instantiated, bullets surround

        var xVariance = Random.Range(0, 7);
        var yVariance = Random.Range(0, 4);

        var xValue = 2 + xVariance;
        var yValue = -2;

        if (player.transform.position.x < transform.position.x)
            xValue *= -1;

        for (int i = 0; i < amountOfBullets; i++)
        {
            var bullet = Instantiate(randomBullet, transform.position, transform.rotation);
            bullet.GetComponent<RandomBullet>().SetMovement(new Vector2(xValue, yValue + yVariance));

            if (yValue > 5)
                yValue *= -1; 

            if(yValue == 0)
                yValue++;

            yValue++;
        }

        StartCoroutine(BulletTime());
    }

}
