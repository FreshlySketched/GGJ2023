using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrab_Eye : MonoBehaviour
{
    public LineRenderer lineRend;
    public Transform stalkPosition;

    public List<Transform> positions = new List<Transform>();

    public Transform targetPosition;

    public float eyeMoveSpeed = 2f;
    public float dstToPos;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = stalkPosition;
    }

    // Update is called once per frame
    void Update()
    {

        //EyeAttack();




    }

    public void EyeAttack()
    {
        //Eyes move up
        //Eyes move forward
        //Eyes swing around
        //Eyes return

        startEyeAttack();
    }

    public void startEyeAttack()
    {
        ConnectLine();

        if (targetPosition != null)
            MoveToPosition();
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
        this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition.position, eyeMoveSpeed * Time.deltaTime);
        dstToPos = Vector3.Distance(this.transform.position, targetPosition.position);
        if (dstToPos <= 1f)
        {
            EyesMoveForward();
        }
    }

    public void ChangePosition()
    {

    }

    public void EyesMoveUp()
    {
        targetPosition = positions[0];
    }

    public void EyesMoveForward()
    {
        //randomly select an attack position
        int posIndx = Random.Range(0, 4);

        targetPosition = positions[posIndx];
    }

    public void EyesSwingAround()
    {

    }

    public void EyesReturn()
    {

    }

}
