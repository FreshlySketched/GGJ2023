using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField]
    private CharacterController2D m_controller;
    [SerializeField]
    private PlayerStart m_startData;

    [SerializeField]
    private bool m_playHit = false;

    [SerializeField]
    private int m_sceneNumber = 0;

    [SerializeField]
    private int m_doorNumber = 0;

    [SerializeField]
    private float m_FadeSpeed = 5;


    [SerializeField]
    private Image image;

    private static bool m_fade = false;
    private float t = 0f;
    private float f = 1f;
    private bool onStart = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (m_playHit && m_controller.m_interaction)
        {
            m_fade = true;
            m_controller.enabled = false;
        }


        if (m_fade)
        {
            if (t < m_FadeSpeed)
            {
                t += Time.deltaTime / m_FadeSpeed;
            }
            image.color = new Color(0, 0, 0, t);

            if(t >= m_FadeSpeed)
            {

                m_startData.m_doorNumber = m_doorNumber;
                SceneManager.LoadScene(m_sceneNumber);
                m_fade = false;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_playHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_playHit = false;
        }
    }

    void Awake()
    {
       
       
    }

    IEnumerator FadeIn()
    {
        onStart = false;
        while (f >= 0)
        {

            f -= Time.deltaTime / m_FadeSpeed;
            image.color = new Color(0, 0, 0, f);
            yield return new WaitForEndOfFrame();
        }
      
    }


}