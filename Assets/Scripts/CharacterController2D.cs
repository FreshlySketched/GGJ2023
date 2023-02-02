using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class CharacterController2D : MonoBehaviour
{
    
    private Rigidbody2D _rb2d;
    public PlayerInputActions _controls;
    [SerializeField] private Transform _groundCheck;
    private bool _grounded;
    [SerializeField] private float _groundCheckRadius = .1f;
    [SerializeField] private LayerMask _whatIsGround;   
    [SerializeField] private float _jumpForce = 50f; //Default to 50
    [SerializeField] private float _moveVelocity = 10f;
   
    [SerializeField] private Health _playerHealth;

    public bool m_interaction = false;
    public bool m_weaponChange = true;

    private Shield _playerShield;

    public bool m_shieldButton = false;
    public bool isPressed;
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
        _controls.Player.Attack_1.performed += LightAttack;
        _controls.Player.Block.started += Shield;
        _controls.Player.Block.canceled += Shield;
        _controls.Player.Special.performed += SpecialAttack;
        _controls.Player.Interact.started += Interact;
        _controls.Player.Interact.canceled += Interact;
        _controls.Player.Jump.performed += Jump;
        _controls.Player.Swap_Weapon.performed += Swap_Weapon;

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
        //Debug.Log(context.action);
        if(_grounded)
            {
                _rb2d.AddForce(new Vector2(0f, (_jumpForce * 10)));
            }
    }    

    private void Update() {

        _playerShield.CheckShieldPress(m_shieldButton);


        if (_playerHealth.currentHealth <= 0)
        {
            //GameManager.Death();
        }

        //need to add a face direction
      
    }

    private void FixedUpdate() 
    {
        _grounded = false;   
        float move = _controls.Player.Move.ReadValue<float>();               
        
        if(Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround))
        {
            _grounded = true;
        }

        //if(_grounded)
        //{
            _rb2d.velocity = new Vector2(move * _moveVelocity, _rb2d.velocity.y);             
        //}        
    }

    private void LateUpdate()
    {
        m_weaponChange = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(_playerShield._blockVal <= 0 || !m_shieldButton)
        {
            if(other.gameObject.CompareTag("Enemy"))
            {
                //float damage = 0;
                //damage -= other.gameObject.GetComponent<DamageDealer>().damage;
                _playerHealth.ChangeHealthBar(other.gameObject.GetComponent<DamageDealer>().damage);
            }
        }        
    }
}
