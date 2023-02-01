using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public Vector2 m_startLocation { get; set; }
    public int m_doorNumber = -1;
    public Transform[] m_doors;
    public int m_health;

    public WeaponManager m_WeaponManger;


    //public bool[] m_weaponsAvaiable;
    private void Start()
    {
    }


    void OnEnable()
    {
        //PlayerPrefs.DeleteAll();

        for (int i = 0; i < m_WeaponManger.m_weapons.Length; i++ )
        {
            m_WeaponManger.m_weapons[i].m_hasBeenActivated = Convert.ToBoolean(PlayerPrefs.GetInt(i.ToString()));
        }

        m_doorNumber = PlayerPrefs.GetInt("DoorNumber");

        if (m_doorNumber - 1 == -1)
            transform.position = new Vector2(0, 2.3f);
        else
            transform.position = m_doors[m_doorNumber - 1].position;
    }


    void OnDisable()
    {
        for (int i = 0; i < m_WeaponManger.m_weapons.Length; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), Convert.ToInt32(m_WeaponManger.m_weapons[i].m_hasBeenActivated));
        }

        PlayerPrefs.SetInt("DoorNumber", m_doorNumber);
        

    }


}
