using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public TMP_Text dialogue;
    [TextArea] public string[] textToDisplay = new string[5];
    private float t = 0f;
    public float fadeTime = 2.5f;
    private bool _fadeInText = false;

    Dictionary<string, bool> textBoxDictionary = new Dictionary<string, bool>();


    private void Start() 
    {
        for(int i = 0; i < textToDisplay.Length; i++)
        {
            textBoxDictionary.Add(textToDisplay[i], false);
            foreach(KeyValuePair<string, bool> kvp in textBoxDictionary)
            Debug.Log(kvp);
        }
    }
    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.CompareTag("Player"))
    //     {
    //         dialogue.color = new Color(1,1,1,0);
    //         dialogue.text = textToDisplay[0];
    //         _fadeInText = true;
    //     }        
    // }

    // private int WhichTextBoxToDisplay()
    // {
    //     for(int i = 0; i < textToDisplay.Length; i++)
    //     {

    //     }
        
    //     return 0;
    // }

    // void Update()
    // {
    //     if(t < fadeTime && _fadeInText)
    //     {
    //         t += Time.deltaTime/fadeTime;
    //     }
    //     dialogue.color = new Color(1,1,1,t); 

    //     if(dialogue.color.a >= 1)
    //     {
    //         _fadeInText = false;
    //     }       
    // }
}
