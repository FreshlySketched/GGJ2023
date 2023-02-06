using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int m_health = 100;
    public int damage = 5;
    public LayerMask mask;
    //[SerializeField] private float _knockbackRadius = 0.5f; 
    private bool _playerInKnockback;
    public CharacterController2D player;
    public GameObject m_Bones;

    public BossHealth bossHealth;
    public float knockBackDistance = 1;
    private void Start() {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        //mask = LayerMask.GetMask("Player");

        if (GetComponentInParent<BossHealth>() != null)
        {
            bossHealth = GetComponentInParent<BossHealth>();
        }

    }

    private void Update()
    {
        if (m_health <= 0)
        {
            //if(m_Bones != null) 
                //Instantiate(m_Bones, transform.position,transform.rotation);
            
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
            var color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
            collision.GetComponent<CharacterController2D>().CheckHit(damage, knockbackPos, knockBackDistance);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && collision.gameObject.layer == 8 && !collision.gameObject.GetComponent<CharacterController2D>().m_invunFrames)
        {
            int knockbackPos = 0;

            if (collision.gameObject.transform.position.x < transform.position.x)
                knockbackPos = -10;
            else
                knockbackPos = 10;
            var color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            collision.gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
            collision.GetComponent<CharacterController2D>().CheckHit(damage, knockbackPos, knockBackDistance);
        }
    }

    private void OnDestroy()
    {
        Destroy(transform.root.gameObject);
    }

    public void TakeDamage()
    {
        m_health -= 50;
        bossHealth.TakeDamage(50);
    }
}
