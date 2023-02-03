using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrabManager : MonoBehaviour
{

    public GameObject headObj;
    public GameObject clawObj;
    public GameObject eyeObj1;
    public GameObject eyeObj2;

    [Header("CrabScripts")]
    TentaCrab_Claw crab_Claw_Script;
    TentaCrab_Eye crab_Eye_Script1;
    TentaCrab_Eye crab_Eye_Script2;
    

    [Header("AttackVars")]
    public bool isAttacking;
    public float attackTime;
    public float attackCooldownTime;

    [Header("AttackStates")]
    public AttackStates currentAttackState;
    public enum AttackStates { clawAttack, eyeAttack, chargeAttack };



    [Header ("Charge Attack Vars")]
    public Transform chargeStartPosition;
    public Transform chargeEndPosition;
    public float chargeSpeed;
    public float returnSpeed;

    [Header("ChargeStates")]
    public ChargeStates currentChargeState;
    public enum ChargeStates { chargeForward, chargeReturn };


    




    // Start is called before the first frame update
    void Start()
    {
        //Attack();
        currentChargeState = ChargeStates.chargeForward;

        crab_Claw_Script = FindObjectOfType<TentaCrab_Claw>();
        crab_Eye_Script1 = eyeObj1.GetComponent<TentaCrab_Eye>();
        crab_Eye_Script2 = eyeObj2.GetComponent<TentaCrab_Eye>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownTime);
        isAttacking = true;
    }

    public void Attack()
    {
        //we look at our previous attacks and the distance to the player
        //select an attack
        //carry out attack
        //return and wait

        //Create StateMachine Here


        if (isAttacking)
        {
            AttackStateMachine();
        }
        else
        {
            //Idle
        }
        




    }

    public void AttackStateMachine()
    {
        

        switch (currentAttackState)
        {
            case AttackStates.clawAttack:
                //claw attack
                crab_Claw_Script.startClawAttack();
                break;
            case AttackStates.eyeAttack:
                //eye attack
                crab_Eye_Script1.startEyeAttack();
                crab_Eye_Script2.startEyeAttack();
                break;
            case AttackStates.chargeAttack:
                //charge attack
                ChargeAttack_SM();
                break;
        }

    }

    public void ChargeAttack_SM()
    {

        switch (currentChargeState)
        {
            case ChargeStates.chargeForward:
                ChargeForward();
                break;
            case ChargeStates.chargeReturn:
                ChargeReturn();
                break;

        }

    }

    public void ChargeForward()
    {
        //Move Crab Forward at high speed
        this.transform.position = Vector3.MoveTowards(this.transform.position, chargeEndPosition.position, chargeSpeed * Time.deltaTime);
        float dstToPos = Vector3.Distance(this.transform.position, chargeEndPosition.position);
        if (dstToPos <= 1f)
        {
            currentChargeState = ChargeStates.chargeReturn;
            ChargeReturn();
        }
    }

    public void ChargeReturn()
    {
        //Move Crab back at low Speed
        this.transform.position = Vector3.MoveTowards(this.transform.position, chargeStartPosition.position, returnSpeed * Time.deltaTime);
        float dstToPos = Vector3.Distance(this.transform.position, chargeStartPosition.position);
        if (dstToPos <= 1f)
        {
            currentChargeState = ChargeStates.chargeForward;
            ChargeForward();
        }
    }

    public void EyeAttack_SM()
    {

        switch (currentChargeState)
        {
            case ChargeStates.chargeForward:
                //
                break;
            case ChargeStates.chargeReturn:
                //ChargeReturn();
                break;

        }

    }

}





