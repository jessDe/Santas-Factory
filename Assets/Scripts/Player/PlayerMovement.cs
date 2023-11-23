using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] InputActionAsset inputActions;

    [Space]

    [Range(1f, 35f)]
    [SerializeField] float walkSpeed;

    [Range(1f, 35f)]
    [SerializeField] float sprintSpeed;

    [Range(1f, 35f)]
    [SerializeField] float sneakSpeed;

    [Space]

    [Tooltip("In Seconds")]
    [Range(1f, 5f)]
    public float SprintDuration;

    CharacterController controller;

    // Input Actions
    InputAction moveAction;
    InputAction sprintAction;
    InputAction sneakAction;

    // Inputs
    Vector2 inputVec;

    bool isSprintingInputActive;
    bool isSprinting;

    bool isSneakingInputActive;
    bool isSneaking;

    float speed;

    public float SprintStamina { get; private set; }

    #region Mono Initialization
    private void Awake()
    {
        moveAction = inputActions.FindActionMap("movement").FindAction("move");
        sprintAction = inputActions.FindActionMap("movement").FindAction("sprint");
        sneakAction = inputActions.FindActionMap("movement").FindAction("sneak");
    }

    private void Start()
    {
        if (inputActions == null)
            Debug.LogError("PlayerMovement has no Input Actions assigned.");

        controller = GetComponent<CharacterController>();

        SprintStamina = SprintDuration;
    }
    #endregion

    #region Update Functions
    private void Update()
    {
        ReadInput();
        HandleSprinting();
        HandleSneaking();
        HandleMovement();
    }
    #endregion

    #region Custom Functions
    private void ReadInput()
    {
        inputVec = moveAction.ReadValue<Vector2>();
        isSprintingInputActive = sprintAction.ReadValue<float>() > 0.5f;
        isSneakingInputActive = sneakAction.ReadValue<float>() > 0.5f;
    }

    private void HandleMovement()
    {
        if (isSprinting)
            speed = sprintSpeed;
        else if (isSneaking)
            speed = sneakSpeed;
        else
            speed = walkSpeed;

        float horizontalSpeed = inputVec.x * speed;
        float verticalSpeed = inputVec.y * speed;

        Vector3 speedVec = new(horizontalSpeed, 0f, verticalSpeed);
        speedVec = transform.rotation * speedVec;

        controller.SimpleMove(speedVec);
    }

    private void HandleSprinting()
    {
        if (isSprintingInputActive && SprintStamina > 0f)
        {
            isSprinting = true;
            SprintStamina -= Time.deltaTime;
        }
        else
        {
            isSprinting = false;
            SprintStamina += (!isSprintingInputActive) ? Time.deltaTime : 0f;
        }

        SprintStamina = Mathf.Clamp(SprintStamina, 0f, SprintDuration);
    }

    private void HandleSneaking()
    {
        if (isSneakingInputActive)
        {
            isSneaking = true;
            Debug.Log("Sneaking");
        }
    }
    #endregion

    #region Setup and Teardown
    private void OnEnable()
    {
        moveAction.Enable();
        sprintAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        sprintAction.Disable();
    }
    #endregion
}
