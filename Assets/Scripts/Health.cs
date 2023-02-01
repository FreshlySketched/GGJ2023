using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;
    [SerializeField] private float _maxHealth = 25f;
    public Slider healthbar;

    private void Awake() 
    {
        currentHealth = _maxHealth;
        if(healthbar!=null)
            healthbar.maxValue = _maxHealth;
    }

    private void Start() 
    {
        if (healthbar != null)
            healthbar.value = currentHealth;
    }  

    public void ChangeHealthBar(float amount) 
    {
        currentHealth -= amount;

        if (healthbar != null)
            healthbar.value = currentHealth;
    }


}
