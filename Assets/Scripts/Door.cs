using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    public Vector3 Destination = new Vector3(0, 0, 0);
    [SerializeField]
    private CharacterController2D controller;
    [SerializeField]
    private PlayerStart startData;
    // Start is called before the first frame update
    void Start()
    {
        controller._controls.Player.Interact.performed += PlayerInteract;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }

    private void PlayerInteract(InputAction.CallbackContext context)
    {
        Debug.Log(context.action);
    }
}
