using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int m_health = 100;
    public int damage = 5;
    public LayerMask mask;
    [SerializeField] private float _knockbackRadius = 0.5f; 
    private bool _playerInKnockback;
    public CharacterController2D player;
    public GameObject m_Bones;
    private void Start() {
        //mask = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        if (m_health == 0)
        {
            if(m_Bones != null) 
                Instantiate(m_Bones, transform.position,transform.rotation);
            
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.layer == 8)
        {
            int knockbackPos = 0;
            
            if (collision.gameObject.transform.position.x < transform.position.x)
                knockbackPos = -10;
            else
                knockbackPos = 10;

            collision.GetComponent<CharacterController2D>().CheckHit(damage, knockbackPos);
        }
    }
}
