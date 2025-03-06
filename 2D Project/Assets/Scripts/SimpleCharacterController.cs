using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;

    public UnityEvent keypressEvent;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(f: jumpForce * -2f * gravity);
            StaminaFunction();
        }
    }

    private void MoveCharacter()
    {
        var moveInput = Input.GetAxis("Horizontal");
        var move= new Vector3(x:moveInput, y:0f, z:0f) * (moveSpeed * Time.deltaTime);
        controller.Move(move);
    }

    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }

        controller.Move( velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
    public void StaminaFunction()
    {
        keypressEvent.Invoke();
    }
}
/*
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SimpleCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private Transform thisTransform;

    private Stamina stamina; // Stamina reference

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
        stamina = GetComponent<Stamina>(); // Get the Stamina script
    }

    private void Update()
    {
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnXAxis();

        if (Input.GetButtonDown("Jump") && controller.isGrounded && stamina.currentStamina > 0)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            stamina.UseStamina(15f); // Deduct stamina for jumping
        }
    }

    private void MoveCharacter()
    {
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3(moveInput, 0f, 0f) * (moveSpeed * Time.deltaTime);
    
        if (moveInput != 0 && stamina.currentStamina > 0)
        {
            stamina.SetMoving(true);
            Debug.Log("Player is moving, stamina should decrease.");
        }
        else
        {
            stamina.SetMoving(false);
            Debug.Log("Player stopped, stamina should regenerate.");
        }

        controller.Move(move);
    }


    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = 0f;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void KeepCharacterOnXAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}
*/
