using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrab_Claw : MonoBehaviour
{
    public Animator animator;

    public enum ClawStates { clawWindup, clawAttack, clawIdle };
    public ClawStates currentClawState;

    public float clawAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ClawAttack_SM()
    {
        bool attackComplete = false;

        switch (currentClawState)
        {
            case ClawStates.clawAttack:
                StartClawAttack();
                break;
            case ClawStates.clawIdle:
                EndClawAttack();
                attackComplete = true;
                break;
        }

        return attackComplete;
    }

    IEnumerator ClawAttackTimer()
    {
        yield return new WaitForSeconds(clawAttackTime);
        animator.SetBool("isClawAttack", false);
        currentClawState = ClawStates.clawIdle;

    }

    public void StartClawAttack()
    {

        animator.SetBool("isClawAttack", true);
        currentClawState = ClawStates.clawAttack;
        StartCoroutine(ClawAttackTimer());

    }

    public void EndClawAttack()
    {
        animator.SetBool("isClawAttack", false);
    }
}
