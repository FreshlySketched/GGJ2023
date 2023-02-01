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
        healthbar.maxValue = _maxHealth;
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
