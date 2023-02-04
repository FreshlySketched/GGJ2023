using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrab_Head : MonoBehaviour
{
    public enum HeadStates {headWindup,headAttack,headReturn, headIdle};
    public HeadStates currentHeadState;

    public float headWindUpTime;
    public float headAttackTime;

    public LineRenderer lineRend;
    public Transform stalkPosition;

    public List<Transform> positions = new List<Transform>();

    public Transform targetPosition;

    public float headMoveSpeed = 2f;
    public float dstToPos;

    // Start is called before the first frame update
    void Start()
    {
        currentHeadState = HeadStates.headReturn;
        targetPosition = stalkPosition;
    }

    // Update is called once per frame
    void Update()
    {
        HeadAttack_SM();
    }

    public bool HeadAttack_SM()
    {
        bool attackComplete = false;

        switch (currentHeadState)
        {
            case HeadStates.headWindup:
                HeadWindUp();
                break;
            case HeadStates.headAttack:
                HeadAttack();
                break;
            case HeadStates.headReturn:
                HeadReturn();
                break;
            case HeadStates.headIdle:
                HeadIdle();
                attackComplete = true;
                break;
        }

        MoveToPosition();

        return attackComplete;
    }

    public void StartHeadAttack()
    {
        
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

        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.position, headMoveSpeed * Time.deltaTime);
        dstToPos = Vector3.Distance(this.transform.position, targetPosition.position);
        if (dstToPos <= 1f)
        {
            if(currentHeadState == HeadStates.headAttack)
            {
                HeadMoveForward();

            }
            else if (currentHeadState == HeadStates.headReturn )
            {
                currentHeadState = HeadStates.headIdle;
            }

        }
    }

    public void ChangePosition()
    {

    }

    public void HeadWindUp()
    {
        HeadMoveUp();
        StartCoroutine(HeadWindUpTimer());
    }

    IEnumerator HeadWindUpTimer()
    {
        yield return new WaitForSeconds(headWindUpTime);
        HeadMoveForward();
        currentHeadState = HeadStates.headAttack;


    }

    IEnumerator HeadAttackTimer()
    {
        yield return new WaitForSeconds(headAttackTime);
        currentHeadState = HeadStates.headReturn;

    }

    public void HeadMoveUp()
    {
        targetPosition = positions[0];
    }

    public void HeadAttack()
    {
        StartCoroutine(HeadAttackTimer());
    }

    public void HeadMoveForward()
    {
        dstToPos = Vector3.Distance(this.transform.position, targetPosition.position);
        if (dstToPos <= 1f)
        {
            //randomly select an attack position
            int posIndx = Random.Range(0, 4);

            targetPosition = positions[posIndx];
        }

            
    }

    public void HeadReturn()
    {
        targetPosition = stalkPosition;
    }

    public void HeadIdle()
    {

    }

}
