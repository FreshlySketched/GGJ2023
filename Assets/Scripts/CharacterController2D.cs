using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    
    private Rigidbody2D _rb2d;
    public PlayerInputActions _controls;
    [SerializeField] private Transform _groundCheck;
    private bool _grounded;
    [SerializeField] private float _groundCheckRadius = .1f;
    [SerializeField] private LayerMask _whatIsGround;   
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _moveVelocity = 10f;


    private Shield _shield;

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
        Debug.Log(context.action);
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
        //Debug.Log(context.action);
        if(_grounded)
            {
                _rb2d.AddForce(new Vector2(0f, (_jumpForce * 10)));
            }
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
        
    }
}
