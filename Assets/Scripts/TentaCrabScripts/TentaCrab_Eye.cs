using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrab_Eye : MonoBehaviour
{
    public enum EyeStates {eyeWindup,eyeAttack,eyeReturn, eyeIdle};
    public EyeStates currentEyeState;

    public float eyeWindUpTime;
    public float eyeAttackTime;

    public LineRenderer lineRend;
    public Transform stalkPosition;

    public List<Transform> positions = new List<Transform>();

    public Transform targetPosition;

    public float eyeMoveSpeed = 2f;
    public float dstToPos;

    // Start is called before the first frame update
    void Start()
    {
        currentEyeState = EyeStates.eyeReturn;
        targetPosition = stalkPosition;
    }

    // Update is called once per frame
    void Update()
    {

        //EyeAttack();



        EyeAttack_SM();


    }

    public bool EyeAttack_SM()
    {
        bool attackComplete = false;

        switch (currentEyeState)
        {
            case EyeStates.eyeWindup:
                EyesWindUp();
                break;
            case EyeStates.eyeAttack:
                EyesAttack();
                break;
            case EyeStates.eyeReturn:
                EyesReturn();
                break;
            case EyeStates.eyeIdle:
                EyeIdle();
                attackComplete = true;
                break;
        }

        MoveToPosition();

        return attackComplete;
    }

    public void StartEyeAttack()
    {
        //currentEyeState = EyeStates.eyeWindup;

        //ConnectLine();

        //EyesMoveUp();

        //if (targetPosition != null)
            //MoveToPosition();
    }

    public void ConnectLine()
    {

        //first we get the distance
        float dst = Vector3.Distance(this.transform.position, stalkPosition.position);
        //now divide by 5(round to int) to get the number of segments
        int segments = (int)dst/5;
        lineRend.positionCount = segments + 2;

        for (float i = 1; i < segments+1; i++)
        {
            //lineRend.SetPosition((int)i, Vector3.Lerp(stalkPosition.position, this.transform.position, i/segments));
            lineRend.SetPosition((int)i, Vector3.Lerp(this.transform.position, stalkPosition.position, i /segments));
        }

        //set start and end positions
        
        lineRend.SetPosition(0,  this.transform.position);
        lineRend.SetPosition(segments + 1, stalkPosition.position);

    }

    public void MoveToPosition()
    {
        ConnectLine();

        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.position, eyeMoveSpeed * Time.deltaTime);
        dstToPos = Vector3.Distance(this.transform.position, targetPosition.position);
        if (dstToPos <= 1f)
        {
            if(currentEyeState == EyeStates.eyeAttack)
            {
                EyesMoveForward();

            }
            else if (currentEyeState == EyeStates.eyeReturn )
            {
                currentEyeState = EyeStates.eyeIdle;
            }

        }
    }

    public void ChangePosition()
    {

    }

    public void EyesWindUp()
    {
        EyesMoveUp();
        StartCoroutine(EyesWindUpTimer());
    }

    IEnumerator EyesWindUpTimer()
    {
        yield return new WaitForSeconds(eyeWindUpTime);
        EyesMoveForward();
        currentEyeState = EyeStates.eyeAttack;


    }

    IEnumerator EyesAttackTimer()
    {
        yield return new WaitForSeconds(eyeAttackTime);
        currentEyeState = EyeStates.eyeReturn;

    }

    public void EyesMoveUp()
    {
        targetPosition = positions[0];
    }

    public void EyesAttack()
    {
        //EyesMoveForward();
        StartCoroutine(EyesAttackTimer());
    }

    public void EyesMoveForward()
    {
        dstToPos = Vector3.Distance(this.transform.position, targetPosition.position);
        if (dstToPos <= 1f)
        {
            //randomly select an attack position
            int posIndx = Random.Range(0, 4);

            targetPosition = positions[posIndx];
        }

            
    }

    public void EyesSwingAround()
    {

    }

    public void EyesReturn()
    {
        targetPosition = stalkPosition;
    }

    public void EyeIdle()
    {

    }

}
