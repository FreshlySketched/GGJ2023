using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    private static GameManager _instance;

    public static GameManager Instance 
    { 
        get { return _instance; } 
    } 

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource musicSource;

    private void Awake() 
    { 
        if (_instance != null && _instance != this) 
        { 
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void NewScene(int sceneIndex)
    {
        Debug.Log("Now loading scene at build index " + sceneIndex);
        Setup.NewData();
        SceneManager.LoadScene(sceneIndex);
        
    }

    public void LoadScene()
    {
        //Debug.Log("Now loading scene at build index " + sceneIndex);
       
        SceneManager.LoadScene(Setup.LoadData());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayBGMusic(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }

}
