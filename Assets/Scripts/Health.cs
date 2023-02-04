using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private float _maxHealth = 100f;
    public Slider healthbar;

    public int m_bones = 0;
   

    private void Awake() 
    {
        if (currentHealth == 100)
        {
            currentHealth = _maxHealth;
            healthbar.maxValue = _maxHealth;
        }
    }

    private void Start() 
    {
        healthbar.value = currentHealth;
    }  

    public void ChangeHealthBar(float amount) 
    {

        currentHealth -= amount;
        healthbar.value = currentHealth;
    }


}
