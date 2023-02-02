using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public TMP_Text dialogue;
    [TextArea] public string textToDisplay;
    private float t = 0f;
    public float fadeTime = 2.5f;
    private bool _fadeInText = false;
    private bool _fadeOutText = false;

    private void Start() {
        dialogue.color = new Color (1,1,1,0);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {          
            t = 0;
            dialogue.text = textToDisplay;
            _fadeInText = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {                     
            _fadeInText = false;
            _fadeOutText = true;
        }        
    }

    void Update()
    {
        if(_fadeInText)
        {
            t += (Time.deltaTime)/fadeTime;
            dialogue.color = new Color(1,1,1,t);

            if(t >= 1f)
            {
                _fadeInText = false;
            }
        }

        if(_fadeOutText)
        {
            t -= Time.deltaTime;
            dialogue.color = new Color(1,1,1,t);

            if(t <= 0)
            {
                _fadeOutText = false;
            }
        }
    }

}
