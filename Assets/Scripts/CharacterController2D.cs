using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private PlayerInputActions _controls;
    [SerializeField] private Transform _groundCheck;
    private bool _grounded;
    [SerializeField] private float _groundCheckRadius = .1f;
    [SerializeField] private LayerMask _whatIsGround;   
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _moveVelocity = 10f;
<<<<<<< Updated upstream
=======
    
    private bool m_inRangeOfChatty = false;
   
    [SerializeField] private Health _playerHealth;

    public bool m_interaction = false;
    public bool m_weaponChange = true;
>>>>>>> Stashed changes


    private Shield _shield;

<<<<<<< Updated upstream
=======
    private bool m_dashTimer = false;

    private bool m_hasJumped = false;

    DialogueTrigger m_chattyPerson;

>>>>>>> Stashed changes
    private void Awake() {
        _controls = new PlayerInputActions();
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnEnable(){_controls.Enable();}    
    private void OnDisable(){ _controls.Disable();}

    private void Start() 
    {
        _shield = GetComponent<Shield>();

        //Subscribe to input events.
        _controls.Player.Attack_1.performed += LightAttack;
        _controls.Player.Attack_2.performed += HeavyAttack;
        _controls.Player.Special.performed += SpecialAttack;
        _controls.Player.Interact.performed += Interact;
        _controls.Player.Jump.performed += Jump;
    }

    private void Interact(InputAction.CallbackContext context) 
    {
<<<<<<< Updated upstream
        Debug.Log(context.action);
=======

        if (context.started)
            m_interaction = true;
        else if (context.canceled)
            m_interaction = false;

    }

    private void Swap_Weapon(InputAction.CallbackContext context)
    {
       
        m_weaponChange = true;
>>>>>>> Stashed changes
    }
    private void LightAttack(InputAction.CallbackContext context) 
    {
        Debug.Log(context.action);
    }
    private void HeavyAttack(InputAction.CallbackContext context) 
    {
        Debug.Log(context.action);
    }
    private void SpecialAttack(InputAction.CallbackContext context) 
    {
        Debug.Log(context.action);
    }
    private void Jump(InputAction.CallbackContext context) 
    {
<<<<<<< Updated upstream
        //Debug.Log(context.action);
        if(_grounded)
            {
                _rb2d.AddForce(new Vector2(0f, (_jumpForce * 10)));
            }
=======
        if (!m_hasJumped)
        {
            _rb2d.AddForce(new Vector2(0f, (_jumpForce * 10)));
            m_hasJumped = true;
            _grounded = false;
        }
    }    

    private void Update() {

        _playerShield.CheckShieldPress(m_shieldButton);


        if (_playerHealth.currentHealth <= 0)
        {
            //GameManager.Death();
        }

        if (m_inRangeOfChatty)
        {
            var talkyFellow = m_chattyPerson;
            m_inRangeOfChatty = true;

            if(m_interaction) 
            talkyFellow.OnInteraction.Invoke();
        }

        //need to add a face direction
      
>>>>>>> Stashed changes
    }
    
    

    private void Update() 
    {
        //Continuously check if the block button is being pressed. Allowing it to block Smash Bros style.
        // if(_shield.BlockValue > 0)
        // {
        //     if(_controls.Player.Block.IsPressed())
        //     {
        //         Debug.Log(_controls.Player.Block.name);
        //     }
        // }


    }

    private void FixedUpdate() 
    {
        _grounded = false;
        //Change normalized Vector2 during fixed update.    
        float move = _controls.Player.Move.ReadValue<float>();
               
        
        if(Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround))
        {
            _grounded = true;
        }

        if(_grounded)
        {
            _rb2d.velocity = new Vector2(move * _moveVelocity, _rb2d.velocity.y);             
        }
<<<<<<< Updated upstream
        
=======
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.CompareTag("Enemy"));
        if(col.gameObject.CompareTag("Enemy")){
        
        m_inRangeOfChatty = true;
        m_chattyPerson = col.gameObject.GetComponent<DialogueTrigger>();
        }
        
    }

    private void OnTriggerExit2D()
    {
        m_inRangeOfChatty = false;

    }
    private void OnTriggerStay2D(Collider2D other) {    
        
        
    }




    IEnumerator DashTime()
    {

        yield return new WaitForSeconds(0.06f);
        new Vector2(0f, _rb2d.velocity.y);
        m_dashTimer = false;
>>>>>>> Stashed changes
    }
}
