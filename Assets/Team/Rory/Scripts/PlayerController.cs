using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerModel player;
    void Start()
    {
        playerInput.actions.FindAction("Vertical").performed += OnVerticalOnperformed;
        playerInput.actions.FindAction("Vertical").canceled += OnVerticalOnperformed;
        playerInput.actions.FindAction("Horizontal").performed += OnHorizontalOnperformed;
        playerInput.actions.FindAction("Horizontal").canceled += OnHorizontalOnperformed;
        playerInput.actions.FindAction("Interact").performed += aContext => player.Interact();
        //playerInput.actions.FindAction("Interact").canceled += aContext => player.StopInteract();
        //playerInput.actions.FindAction("Dash").canceled += aContext => playerController.Dash();
        //playerInput.actions.FindAction("Turn").performed += OnCarTurnOnperformed;
        //playerInput.actions.FindAction("Turn").canceled += OnCarTurnOnperformed;
        
    }
    private void OnVerticalOnperformed(InputAction.CallbackContext aContext)
    {
        if (aContext.phase == InputActionPhase.Performed)
        {
            player.Vertical(aContext.ReadValue<float>());
        }
        if(aContext.phase == InputActionPhase.Canceled)
        {
            player.Vertical(0);
        }
    }
    
    private void OnHorizontalOnperformed(InputAction.CallbackContext aContext)
    {
        if (aContext.phase == InputActionPhase.Performed)
        {
            player.Horizontal(aContext.ReadValue<float>());
        }
        if(aContext.phase == InputActionPhase.Canceled)
        {
            player.Horizontal(0);
        }
    }
}
