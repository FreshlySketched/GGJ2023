using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public Vector2 m_startLocation { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        transform.position = new Vector2(PlayerPrefs.GetInt("startX"), PlayerPrefs.GetInt("startY"));
    }


    void OnDisable()
    {
        PlayerPrefs.SetFloat("startX", m_startLocation.x);
        PlayerPrefs.SetFloat("startY", m_startLocation.y);
    }



}
