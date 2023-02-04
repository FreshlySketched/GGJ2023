using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCurveJump : MonoBehaviour
{
    public Transform landingTarget;

    // Time to move from sunrise to landingTarget position, in seconds.
    public float journeyTime = 1.0f;

    // The time at which the animation started.
    private float startTime;

    void Start()
    {
        // Note the time at the start of the animation.
        startTime = Time.time;
    }

    void Update()
    {
        // The center of the arc
        Vector3 center = (transform.position + landingTarget.position) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= new Vector3(0.5f, 0.5f, 0);

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = transform.position - center;
        Vector3 setRelCenter = landingTarget.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;

        //transform.position = Vector3.SlerpUnclamped(transform.position, riseRelCenter, fracComplete);
        transform.position = Vector3.SlerpUnclamped(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;
    }
    // [SerializeField] AnimationCurve _jumpcurve;

    // [SerializeField] float _bearJumpSpeed;
    // [SerializeField] float _bearJumpHeight;
    // [SerializeField] float _bearMaxJumpDistance;

    // private Vector3 endPoint;
    // public GameObject player;

    // IEnumerator coroutine = null;


    // void Update()
    // {
    //     endPoint = player.transform.position;
        
    //     if((endPoint.x - transform.position.x) < _bearMaxJumpDistance)
    //     {
    //         if(coroutine == null)
    //         {
    //             coroutine = FollowCurve();
    //             StartCoroutine(coroutine);
    //         }
    //     }

        
    // }

    // IEnumerator FollowCurve()
    // {
    //     Vector3 pathVector = endPoint - transform.position;
    //     float totalDistance = pathVector.magnitude;
    //     pathVector.Normalize();
    //     float bearRadius = transform.localScale.y / 2.0f;

    //     float distanceTravelled = 0f;
    //     Vector3 newPos = transform.position;

    //     while (distanceTravelled <= totalDistance)
    //     {
    //         Vector3 deltaPath = pathVector * (_bearJumpSpeed * Time.deltaTime);
    //         newPos += deltaPath;
    //         distanceTravelled += deltaPath.magnitude;
    //         newPos.y = bearRadius - (_bearJumpHeight * _jumpcurve.Evaluate(distanceTravelled/totalDistance));

    //         transform.position = newPos;

    //         yield return null;
    //     }

    //     coroutine = null;

    // }
}
