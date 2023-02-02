using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrabManager : MonoBehaviour
{

    public GameObject headObj;
    public GameObject clawObj;
    public GameObject eyeObj1;
    public GameObject eyeObj2;


    [Header ("Charge Attack Vars")]
    public Transform chargeStartPosition;
    public Transform chargeEndPosition;
    public float chargeSpeed;
    public float returnSpeed;

    [Header("ChargeStates")]
    public States currentState;
    public enum States { chargeForward, chargeReturn };




    // Start is called before the first frame update
    void Start()
    {
        //Attack();
        currentState = States.chargeForward;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        //we look at our previous attacks and the distance to the player
        //select an attack
        //carry out attack
        //return and wait


        //Create StateMachine Here
        AttackStateMachine();

    }

    public void AttackStateMachine()
    {

        ChargeAttack_SM();
    }

    public void ChargeAttack_SM()
    {

        switch (currentState)
        {
            case States.chargeForward:
                ChargeForward();
                break;
            case States.chargeReturn:
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
            currentState =States.chargeReturn;
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
            currentState = States.chargeForward;
            ChargeForward();
        }
    }

}





