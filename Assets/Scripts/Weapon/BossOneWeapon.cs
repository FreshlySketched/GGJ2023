using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneWeapon : BaseWeapon
{
    // Start is called before the first frame update
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
