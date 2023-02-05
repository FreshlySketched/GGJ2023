using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{
    public string bossName;
    public TextMeshProUGUI bossLabel;

    public float currentHealth;
    public float _maxHealth = 100f;
    public Slider healthbar;

    public List<DamageDealer> damageDealerList = new List<DamageDealer>();

    public GameObject m_Bones;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = _maxHealth;

        if (bossLabel != null)
            bossLabel.text = bossName;

        if(healthbar != null)
        {
            healthbar.maxValue = _maxHealth;
            healthbar.value = currentHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
            if (m_Bones != null)
                Instantiate(m_Bones, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

    public void TakeDamage(float dmgValue)
    {
        currentHealth -= dmgValue;
        ChangeHealthBar(dmgValue);
    }
    public void ChangeHealthBar(float amount)
    {
        healthbar.value = currentHealth;
    }

}
