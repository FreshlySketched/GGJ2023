using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStart : MonoBehaviour
{
    public Vector2 m_startLocation { get; set; }
    public int m_doorNumber = -1;
    public Transform[] m_doors;
    public int m_health;

    public WeaponManager m_WeaponManger;
    public Health m_Health;


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

        m_Health.currentHealth = PlayerPrefs.GetFloat("Health");
        m_Health.m_bones = PlayerPrefs.GetInt("Bones");
        m_Health.healthbar.value = PlayerPrefs.GetFloat("Health");
        if (GameObject.FindGameObjectWithTag("Alter") != null)
            GameObject.FindGameObjectWithTag("Alter").GetComponent<Alter>().m_totalBones = PlayerPrefs.GetInt("TotalBones");
    }


    void OnDisable()
    {
        for (int i = 0; i < m_WeaponManger.m_weapons.Length; i++)
        {
            PlayerPrefs.SetInt(i.ToString(), Convert.ToInt32(m_WeaponManger.m_weapons[i].m_hasBeenActivated));
        }

        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("DoorNumber", m_doorNumber);
        PlayerPrefs.SetFloat("Health", m_Health.currentHealth);
        PlayerPrefs.SetInt("Bones", m_Health.m_bones);
        if (GameObject.FindGameObjectWithTag("Alter") != null)
            PlayerPrefs.SetInt("TotalBones",GameObject.FindGameObjectWithTag("Alter").GetComponent<Alter>().m_totalBones);

    }



    private void Update()
    {
        if(m_Health.currentHealth <= 0 || transform.position.y < -15f)
        {
            m_Health.currentHealth = 100;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
