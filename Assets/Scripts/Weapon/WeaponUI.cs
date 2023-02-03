using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public WeaponManager weaponManger;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>().sprite != weaponManger.m_currentWeapon.gameObject.GetComponent<SpriteRenderer>().sprite)
            GetComponent<Image>().sprite = weaponManger.m_currentWeapon.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
