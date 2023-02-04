using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemy : MonoBehaviour
{
    public GameObject m_player;
    public float speed = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        
        if (Vector3.Distance(transform.position, m_player.transform.position) < 8.0f)
            transform.position = Vector3.MoveTowards(transform.position, m_player.transform.position, step);

    }
}
