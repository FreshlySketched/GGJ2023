using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Alter : MonoBehaviour
{
    public TextMeshPro textbox;
    public int m_totalBones = 0;
    public GameObject finalDoor;
    // Start is called before the first frame update
    void Start()
    {
        textbox.text = m_totalBones.ToString() + "/3";
        finalDoor.SetActive(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStart>().m_secondDoor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            m_totalBones += collision.gameObject.GetComponent<Health>().m_bones;
            textbox.text = m_totalBones.ToString() + "/3";

            collision.gameObject.GetComponent<Health>().m_bones = 0;

            if (m_totalBones == 2)
            {
                finalDoor.SetActive(true);
                collision.GetComponent<PlayerStart>().m_secondDoor = true;
            }

            if (m_totalBones >= 3)
            {
                m_totalBones = 0;
                collision.gameObject.GetComponent<PlayerStart>().m_doorNumber = 0;

                collision.transform.position = new Vector2(0, 2.3f);

                PlayerPrefs.SetInt("DoorNumber", 0);
                PlayerPrefs.SetFloat("Health", 100);
                PlayerPrefs.SetInt("Bones", 0);
                PlayerPrefs.SetInt("TotalBones", 0);
                PlayerPrefs.Save();
                
                foreach (BaseWeapon weapon in collision.gameObject.GetComponent<WeaponManager>().m_weapons)
                {
                    weapon.m_hasBeenActivated = false;
                }

                GameManager.Instance.SelectMusic(3);
                SceneManager.LoadScene("Ending");

            }


            
        }
    }
}
