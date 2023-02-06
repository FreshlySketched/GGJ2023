using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrentBones : MonoBehaviour
{
    public Health m_health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Bones Collected: " + m_health.m_bones.ToString();
    }
}
