using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBoss : MonoBehaviour
{
    public CharacterController2D m_player;
    bool m_playerInRange = false;
    public float m_maxDashDistance = 3f;
    public float m_punchSpacing = 0.25f;
    public float m_moveSpeed = 1f;
    private bool m_punching = false;
    [SerializeField] private GameObject[] m_fists = new GameObject[2];

    public Animator bearAnimator;

    public void Start()
    {
        bearAnimator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            m_playerInRange = true;
        }
    }

    private void Update() 
    {
        FacePlayer();

        AttackPlayer();
    }

    public void FacePlayer()
    {
        Vector3 playerPos = m_player.gameObject.transform.position;
        float distanceDelta = Vector3.Distance(playerPos, transform.position);

        if (playerPos.x - this.transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if (playerPos.x - this.transform.position.x < 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void AttackPlayer()
    {
        Vector3 playerPos = m_player.gameObject.transform.position;
        float distanceDelta = Vector3.Distance(playerPos, transform.position);

        

        float step = m_moveSpeed * Time.deltaTime;

        if (m_player != null)
        {
            if (!m_playerInRange)
            {

                //DashAttack
                DashAttack(playerPos, distanceDelta, step);

            }
            else if (m_playerInRange)
            {
                if (m_player.m_shieldButton)
                {
                    Grapple();
                }
                else
                {
                    WomboCombo();
                }
            }
        }
    }
    
    private void WomboCombo()
    {
        Vector3 fOneStartPos = m_fists[0].transform.position;
        Vector3 fTwoStartPos = m_fists[1].transform.position;
        Debug.Log("WOMBO COMBO!");
        if(m_punching == false)
        {
            m_fists[0].transform.position = m_player.transform.position;
            StartCoroutine(ComboTiming());
        }
        else if(m_punching == true)
        {
            m_fists[1].transform.position = m_player.transform.position;
            m_punching = false;
            
        }
        
        

    }

    private void DashAttack(Vector3 playerPos, float distanceDelta, float step)
    {
        if (distanceDelta > m_maxDashDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, step);
            bearAnimator.SetBool("Punch", false);
        }
        else if (distanceDelta <= m_maxDashDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, (step * 3));
            bearAnimator.SetBool("Punch", true);
        }
    }

    private void Grapple()
    {
        Debug.Log("GOTCHA!");
    }

    IEnumerator ComboTiming()
    {
        yield return new WaitForSeconds(m_punchSpacing);
        m_punching = true;
    }


}
