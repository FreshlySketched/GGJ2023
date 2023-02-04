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

        if(mask != 0)
        {        
        Collider2D checkRadius = Physics2D.OverlapCircle(transform.position, _knockbackRadius);
            if(checkRadius)
            {
                //fix this... it goes the wrong way. 
                player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.MoveTowards(player.gameObject.transform.position, -transform.position, 10);
            }
        }
    }  
}
