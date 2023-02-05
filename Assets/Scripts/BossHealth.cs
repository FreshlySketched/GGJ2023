using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private float _maxHealth = 100f;
    public Slider healthbar;

    public List<DamageDealer> damageDealerList = new List<DamageDealer>();

    public GameObject m_Bones;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
