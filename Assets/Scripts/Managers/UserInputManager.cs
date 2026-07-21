using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputManager : MonoBehaviour
{
    public static UserInputManager instance;
    public UserInput userInput;

    private InputAction playerMovement;
    public InputAction playerJump { get; private set; }
    public InputAction playerAttack { get; private set; }

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;

        userInput = new UserInput();
    }

    private void OnEnable()
    {
        // Player Movements
        playerMovement = userInput.Player.Movement;
        playerMovement.Enable();

        // Player Jump
        playerJump = userInput.Player.Jump;
        playerJump.Enable();

        // Player Attack
        playerAttack = userInput.Player.Attack;
        playerAttack.Enable();
    }

    private void OnDisable()
    {
        // Player Movements
        playerMovement.Disable();

        // Player Jump
        playerJump.Disable();

        // Player Attack
        playerAttack.Disable();
    }

    public void Update()
    {
        horizontalMovement();
    }
    public Vector2 horizontalMovement() => playerMovement.ReadValue<Vector2>();
}
