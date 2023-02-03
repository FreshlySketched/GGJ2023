using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField]
    private int m_Damage = 25;
    public bool m_hasBeenActivated = false;

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

}
