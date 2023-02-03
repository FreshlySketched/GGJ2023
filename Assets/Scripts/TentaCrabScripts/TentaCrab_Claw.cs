using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentaCrab_Claw : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startClawAttack()
    {
        animator.SetBool("isClawAttack", true);
    }

    public void endClawAttack()
    {
        animator.SetBool("isClawAttack", false);
    }
}
