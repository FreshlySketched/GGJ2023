using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneWeapon : BaseWeapon
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
        yield return new WaitForSeconds(0.2f);
        this.gameObject.SetActive(false);
    }



}
