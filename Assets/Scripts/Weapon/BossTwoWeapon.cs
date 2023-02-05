using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossTwoWeapon : BaseWeapon
{

    public override void PerformAttack()
    {
        StartCoroutine(AttackWait());
    }


    IEnumerator AttackWait()
    {
        animator.SetInteger("Attack", number);
        yield return new WaitForSeconds(0.2f);

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<DamageDealer>().TakeDamage();

        }

    }


}
