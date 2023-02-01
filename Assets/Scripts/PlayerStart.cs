using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public Vector2 m_startLocation { get; set; }
    public int m_doorNumber = -1;
    public Transform[] doors;


    void OnEnable()
    {
       
        m_doorNumber = PlayerPrefs.GetInt("DoorNumber");

        if (m_doorNumber - 1 == -1)
            transform.position = new Vector2(0, 2.3f);
        else
            transform.position = doors[m_doorNumber - 1].position;
    }


    void OnDisable()
    {
        PlayerPrefs.SetInt("DoorNumber", m_doorNumber);
        if(!UnityEditor.EditorApplication.isPlaying)
            PlayerPrefs.DeleteAll();
    }


}
