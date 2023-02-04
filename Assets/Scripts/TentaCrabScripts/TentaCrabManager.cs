using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrabManager : MonoBehaviour
{

    public GameObject bodyObj;
    public GameObject clawObj;
    public GameObject headObj;

    [Header("CrabScripts")]
    public TentaCrab_Claw crab_Claw_Script;
    public TentaCrab_Head crab_Head_Script;
    

    [Header("AttackVars")]
    public bool isAttacking = false;
    public bool isCoolingDown = false;
    public bool coroutineRunning = false;
    public float attackTime;
    public float attackCooldownTime;

    [Header("AttackStates")]
    public AttackStates currentAttackState;
    public enum AttackStates { clawAttack, headAttack, chargeAttack };



    [Header ("Charge Attack Vars")]
    public Transform chargeStartPosition;
    public Transform chargeEndPosition;
    public float chargeWindUpTime;
    public float chargeAttackTime;
    public float chargeSpeed;
    public float returnSpeed;

    [Header("ChargeStates")]
    public ChargeStates currentChargeState;
    public enum ChargeStates { chargeWindup, chargeForward, chargeReturn };


    // Start is called before the first frame update
    void Start()
    {
        //Attack();
        currentChargeState = ChargeStates.chargeWindup;

        crab_Claw_Script = FindObjectOfType<TentaCrab_Claw>();
        crab_Head_Script = headObj.GetComponent<TentaCrab_Head>();
    }

    // Update is called once per frame
    void Update()
    {
        RunAttackLogic();
    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(attackTime);
        coroutineRunning = false;
        isAttacking = false;
        isCoolingDown = true;
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldownTime);
        coroutineRunning = false;
        isAttacking = true;
        isCoolingDown = false;
    }

    public void BeginAttack()
    {
        
    }

    public void RunAttackLogic()
    {
        //we look at our previous attacks and the distance to the player
        //select an attack
        //carry out attack
        //return and wait

        AttackStateMachine();



        if (isAttacking && !coroutineRunning)
        {
            coroutineRunning = true;
            AttackStateMachine();
            //StartCoroutine(AttackTimer());
            
        }
        else if(isCoolingDown && !coroutineRunning)
        {
            coroutineRunning = true;
            //StartCoroutine(AttackCooldown());
            //Idle
        }
    }

    public void AttackStateMachine()
    {
        

        switch (currentAttackState)
        {
            case AttackStates.clawAttack:
                //claw attack
                ClawAttack_SM();
                break;
            case AttackStates.headAttack:
                //head attack
                HeadAttack_SM();
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
            case ChargeStates.chargeWindup:
                ChargeWindup();
                break;
            case ChargeStates.chargeForward:
                ChargeForward();
                break;
            case ChargeStates.chargeReturn:
                ChargeReturn();
                break;

        }

    }

    public void SwitchAttack()
    {
        int attackIndex = Random.Range(0, 3);

        switch (attackIndex)
        {
            case 0:
                currentAttackState = AttackStates.clawAttack;
                currentChargeState = ChargeStates.chargeWindup;
                break;
            case 1:
                currentAttackState = AttackStates.headAttack;
                crab_Head_Script.currentHeadState = TentaCrab_Head.HeadStates.headWindup;
                break;
            case 2:
                currentAttackState = AttackStates.chargeAttack;
                break;
        }
    }



    public void ChargeWindup()
    {
        bodyObj.GetComponent<StrobeEffect>().isStrobing = true;
        StartCoroutine(ChargeWindUpTimer());
    }

    IEnumerator ChargeWindUpTimer()
    {
        yield return new WaitForSeconds(chargeWindUpTime);
        bodyObj.GetComponent<StrobeEffect>().isStrobing = false;
        currentChargeState = ChargeStates.chargeForward;

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
            SwitchAttack();

            //currentChargeState = ChargeStates.chargeForward;
            //ChargeForward();
        }
    }

    public void HeadAttack_SM()
    {
        bool headFin = crab_Head_Script.HeadAttack_SM();
        if(headFin == true)
        {
            SwitchAttack();
            //crab_Head_Script.currentHeadState = TentaCrab_Head.HeadStates.headAttack;
        }
    }

    public void ClawAttack_SM()
    {
        bool clawFin = crab_Claw_Script.ClawAttack_SM();
        if(clawFin == true)
        {
            SwitchAttack();
            crab_Claw_Script.currentClawState = TentaCrab_Claw.ClawStates.clawAttack;
        }
    }

}





