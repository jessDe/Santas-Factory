using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Horror
{
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

        [Space]

        [Tooltip("In Seconds")]
        [Range(1f, 5f)]
        public float SprintDuration;

        CharacterController controller;

        // Input Actions
        InputAction moveAction;
        InputAction sprintAction;

        // Inputs
        Vector2 inputVec;

        bool isSprintingInputActive;
        bool isSprinting;
        public float SprintStamina { get; private set; }

        #region Mono Initialization
        private void Awake()
        {
            moveAction = inputActions.FindActionMap("movement").FindAction("move");
            sprintAction = inputActions.FindActionMap("movement").FindAction("sprint");
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
            HandleMovement();
            HandleSprinting();
        }
        #endregion

        #region Custom Functions
        private void ReadInput()
        {
            inputVec = moveAction.ReadValue<Vector2>();
            isSprintingInputActive = sprintAction.ReadValue<float>() > 0.5f;
        }

        private void HandleMovement()
        {
            float horizontalSpeed = inputVec.x * (isSprinting ? sprintSpeed : walkSpeed);
            float verticalSpeed = inputVec.y * (isSprinting ? sprintSpeed : walkSpeed);

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
}
