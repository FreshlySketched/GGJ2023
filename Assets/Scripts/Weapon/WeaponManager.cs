using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    
    public BaseWeapon[] m_weapons;
    public BaseWeapon m_currentWeapon;

    private int m_currentID = 0;

    [SerializeField]
    private CharacterController2D controller;


    // Start is called before the first frame update
    void Start()
    {
        if (m_weapons.Length > 0)
        {
            m_currentWeapon = m_weapons[0];
            m_currentWeapon.m_hasBeenActivated = true;
        }

        else
            Debug.LogError("No Weapons have been added to WeaponManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.m_weaponChange)
        {
            Debug.Log("Swap weapon has occurred");
            ChangeWeapon();
        }
    }

    public void ChangeWeapon()
    {
        
        m_currentWeapon.gameObject.SetActive(false);
        m_currentID++;
       
        while (!m_weapons[m_currentID].m_hasBeenActivated)
        {
            Debug.Log(m_weapons[m_currentID].gameObject.name);
            if (!m_weapons[m_currentID].m_hasBeenActivated)
            {
                m_currentID++;
            }

            if (m_currentID >= m_weapons.Length)
                m_currentID = 0;
        }

        m_currentWeapon = m_weapons[m_currentID];
        m_currentWeapon.gameObject.SetActive(true);

        Debug.Log(m_currentWeapon.gameObject.name + " is the current weapon");

    }



}
