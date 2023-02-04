using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class CharacterController2D : MonoBehaviour
{
    
    private Rigidbody2D _rb2d;
    public PlayerInputActions _controls;
    [SerializeField] private Transform _groundCheck;
    private bool _grounded = true;
    [SerializeField] private float _groundCheckRadius = .1f;
    [SerializeField] private LayerMask _whatIsGround;   
    [SerializeField] private float _jumpForce = 50f; //Default to 50
    [SerializeField] private float _moveVelocity = 10f;
   
    [SerializeField] private Health _playerHealth;

    public bool m_interaction = false;
    public bool m_weaponChange = true;

    private Shield _playerShield;

    public bool m_shieldButton = false;
    public bool m_Attacked = false;
    public bool m_dashed = false;

    [SerializeField] private bool m_inRangeofChatty = false;
    private DialogueTrigger chattyFellow;

    private bool m_dashTimer = false;

    private bool m_hasJumped = false;
    private void Awake() {
        _controls = new PlayerInputActions();
        _rb2d = GetComponent<Rigidbody2D>();
        _playerHealth = GetComponent<Health>();
    }
    private void OnEnable(){_controls.Enable();}    
    private void OnDisable(){ _controls.Disable();}

    private void Start() 
    {
        _playerShield = GetComponent<Shield>();
        //Subscribe to input events.
        _controls.Player.Attack_1.started += LightAttack;
        _controls.Player.Attack_1.canceled += LightAttack;
        _controls.Player.Block.started += Shield;
        _controls.Player.Block.canceled += Shield;
        _controls.Player.Special.performed += SpecialAttack;
        _controls.Player.Interact.started += Interact;
        _controls.Player.Interact.canceled += Interact;
        _controls.Player.Jump.performed += Jump;
        _controls.Player.Swap_Weapon.performed += Swap_Weapon;
        _controls.Player.Dash.performed += Dash;
    }

    private void Interact(InputAction.CallbackContext context) 
    {
        if (context.started)
            m_interaction = true;
        else if (context.canceled)
            m_interaction = false;
    }

    private void Swap_Weapon(InputAction.CallbackContext context)
    {
        m_weaponChange = true;
    }

    private void LightAttack(InputAction.CallbackContext context) 
    {
        if (context.started)
            m_Attacked = true;
    }

    private void Dash(InputAction.CallbackContext context)
    {
        m_dashed = true;
    }


    private void Shield(InputAction.CallbackContext context) 
    {

        if (context.started)
            m_shieldButton = true;

        else if (context.canceled)
            m_shieldButton = false;

    }

    private void SpecialAttack(InputAction.CallbackContext context) 
    {

    }

    private void Jump(InputAction.CallbackContext context) 
    {
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

        if(_controls.Player.Interact.triggered && m_inRangeofChatty)
        {            
            chattyFellow.interactionChat.Invoke();
        }

        //need to add a face direction
      
    }

    private void FixedUpdate() 
    {
        //_grounded = false;   
        float move = _controls.Player.Move.ReadValue<float>();
        //Debug.Log(Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround));
       // if(Physics2D.OverlapCircle(transform.position, _groundCheckRadius, _whatIsGround))
       // {
            
       //}

        if(_grounded)
        {
            m_hasJumped = false;
        }        


        if (m_dashed)
        {
            _rb2d.AddForce(new Vector2(move * 200, 0.0f), ForceMode2D.Impulse);
            m_dashed = false;
            m_dashTimer = true;
            StartCoroutine(DashTime());
            Debug.Log("Has Dashed");
        }

        else if(!m_dashTimer)
            _rb2d.velocity = new Vector2(move * _moveVelocity, _rb2d.velocity.y);
    }

    private void LateUpdate()
    {
        m_weaponChange = false;
        m_Attacked = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_playerShield._blockVal <= 0 || !m_shieldButton)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                //float damage = 0;
                //damage -= other.gameObject.GetComponent<DamageDealer>().damage;
                _playerHealth.ChangeHealthBar(collision.gameObject.GetComponent<DamageDealer>().damage);
            }
        }

        if(collision.gameObject.layer == 6)
        {
            _grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            m_inRangeofChatty = true;
            chattyFellow = other.gameObject.GetComponent<DialogueTrigger>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        m_inRangeofChatty = false;
    }

    IEnumerator DashTime()
    {

        yield return new WaitForSeconds(0.06f);
        new Vector2(0f, _rb2d.velocity.y);
        m_dashTimer = false;
    }
}
