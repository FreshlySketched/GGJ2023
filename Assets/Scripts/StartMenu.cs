using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public AudioClip stone4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSound()
    {
        GameManager.Instance.PlaySound(stone4);
    }

    public void NewGame()
    {
        GameManager.Instance.NewScene(1);
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
