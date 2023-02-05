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

    public AudioClip hubWorldMusic;
    public AudioClip surfaceMusic;
    public AudioClip bossMusic;

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

    private void Start()
    {
        PlaySurfaceBGMusic();
    }
    public void NewScene(int sceneIndex)
    {
        Debug.Log("Now loading scene at build index " + sceneIndex);
        Setup.NewData();
        SceneManager.LoadScene(sceneIndex);
        SelectMusic(sceneIndex);
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

    //Musical Section
    public void PlayHubBGMusic()
    {
        musicSource.Stop();
        PlayBGMusic(surfaceMusic);
    }

    public void PlaySurfaceBGMusic()
    {
        musicSource.Stop();
        PlayBGMusic(hubWorldMusic);
    }

    public void PlayBossBGMusic()
    {
        musicSource.Stop();
        PlayBGMusic(bossMusic);
    }

    public void SelectMusic(int sceneNumber)
    {
        if(sceneNumber == 0 || sceneNumber == 3)
        {
            PlaySurfaceBGMusic();
        }
        else if (sceneNumber == 1)
        {
            PlayHubBGMusic();
        }
        else if (sceneNumber == 2 || sceneNumber == 4 || sceneNumber == 5)
        {
            PlayBossBGMusic();
        }
    }

}
