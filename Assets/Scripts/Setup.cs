using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void NewData()
    {

        PlayerPrefs.DeleteAll();
    }


    public static int LoadData()
    {
        if (PlayerPrefs.HasKey("Scene"))
            return PlayerPrefs.GetInt("Scene");
        else
            return 1;
    }
}

