using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 5;
    LayerMask mask;
    [SerializeField] private float _knockbackRadius = 0.5f; 
    private bool _playerInKnockback;
    public CharacterController2D player;

    private void Start() {
        mask = LayerMask.GetMask("Player");
    }

    private void FixedUpdate() {

        if(mask != 0)
        {        
        Collider2D checkRadius = Physics2D.OverlapCircle(transform.position, _knockbackRadius, mask);
            if(checkRadius)
            {
                //fix this... it goes the wrong way. 
                player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.MoveTowards(player.gameObject.transform.position, -transform.position, 10);
            }
        }
    }  
}