using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField]
    private int m_Damage = 25;
    public bool m_hasBeenActivated = false;
    private float m_startPosition;
    void Start()
    {

    }


    void Update()
    {

    }

    public abstract void PerformAttack();


    public int GetDamage()
    {
        return m_Damage;
    }

    public void FlipWeapon(bool isFlipped)
    {
        if (isFlipped)
        {
            transform.localPosition = new Vector3(1f, transform.localPosition.y, transform.localPosition.z);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.localPosition = new Vector3(-1f, transform.localPosition.y, transform.localPosition.z);
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

}
