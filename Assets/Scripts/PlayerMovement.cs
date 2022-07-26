using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PauseMenu PM;
    //Input
    private InputManager playerInputActions;

    //move
    private Rigidbody2D rb;
    public float Speed;
    private float movementDirection;

    //jump
    private bool isGrounded;
    public Transform feetPos;
    public float checkRedius;
    public LayerMask whatIsGround;
    public float jumpForce;
    public AudioSource jumpSound;

    private void Awake()
    {
        playerInputActions = new InputManager();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Pause.performed += Pause;
        playerInputActions.Player.ResetLevel.performed += ResetLevel;

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRedius,whatIsGround);
    }
    private void FixedUpdate()
    {
        float movementDirection = playerInputActions.Player.Movement.ReadValue<float>();
        rb.velocity = new Vector2(movementDirection * Speed, rb.velocity.y);

        if(movementDirection > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(movementDirection < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
                //jumpSound.Play();
                FindObjectOfType<AudioManager>().Play("Jump");
            }
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if(PM.isPaused == true)
            {
                PM.Resume();
            }
            if(PM.isPaused == false)
            {
                PM.Pause();
            }
        }
    }

    public void ResetLevel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
