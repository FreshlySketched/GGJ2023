using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private Image _rend;
    private float t = 0f;
    public float fadeTime = 2.5f;

    void Start()
    {
        _rend = GetComponent<Image>();     
    }

    void Update()
    {
        if(t < fadeTime)
        {
            t += Time.deltaTime/fadeTime;
        }
        _rend.color = new Color(0,0,0,t);        
    }
}
