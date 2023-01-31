using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrab_Eye : MonoBehaviour
{
    public LineRenderer lineRend;
    public Transform stalkPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConnectLine();
    }

    public void ConnectLine()
    {

        //first we get the distance
        float dst = Vector3.Distance(stalkPosition.position, this.transform.position);
        //now divide by 5(round to int) to get the number of segments
        int segments = (int)dst/5;
        Debug.Log("Segments == " + segments);
        lineRend.positionCount = segments + 2;

        for (float i = 0; i < segments; i++)
        {
            //lineRend.SetPosition((int)i, Vector3.Lerp(stalkPosition.position, this.transform.position, i/segments));
            lineRend.SetPosition((int)i, Vector3.Lerp(this.transform.position, stalkPosition.position, i /segments));
        }

        //set start and end positions
        
        lineRend.SetPosition(0,  this.transform.position);
        lineRend.SetPosition(segments + 1, stalkPosition.position);


    }
}
