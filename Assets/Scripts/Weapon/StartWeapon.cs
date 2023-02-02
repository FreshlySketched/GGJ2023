using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWeapon : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void PerformAttack()
    {
        StartCoroutine(AttackWait());


    }

    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<DamageDealer>().m_health -= 50;
        }


    }



}
