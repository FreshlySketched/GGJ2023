using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncestorBones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<WeaponManager>().m_weapons[1].m_hasBeenActivated = true;
           // Debug.Log(collision.GetComponent<WeaponManager>().m_weapons[1].m_hasBeenActivated);
            collision.gameObject.GetComponent<Health>().m_bones++;
            Destroy(gameObject);
        }
    }
}
