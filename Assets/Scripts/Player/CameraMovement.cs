using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [Header("Camera Movement Settings")]
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] Transform cameraGameObject;
    [SerializeField] Transform camTransform;

    [Space]

    [Range(5f, 100f)]
    [SerializeField] float movementSensitivity;

    Vector2 movementDeltaVec;

    InputAction camMoveAction;

    float xrot = 0f;
    float yrot = 0f;

    #region Mono Initialization
    private void Awake()
    {
        camMoveAction = inputActions.FindActionMap("movement").FindAction("camera");
    }

    private void Start()
    {
        if (inputActions is null)
            Debug.LogError("CameraMovement has no Input Actions assigned.");

        if (camTransform is null)
            Debug.LogError("No Camera Transform assigned.");
    }

    #endregion

    #region Update Functions
    private void Update()
    {
        movementDeltaVec = camMoveAction.ReadValue<Vector2>();

        xrot -= Time.deltaTime * movementSensitivity * movementDeltaVec.y;
        yrot += Time.deltaTime * movementSensitivity * movementDeltaVec.x;

        xrot = Mathf.Clamp(xrot, -75f, 75f);

        camTransform.rotation = Quaternion.Euler(xrot, yrot, 0f);
        transform.localRotation = Quaternion.Euler(0f, yrot, 0f);

        cameraGameObject.transform.position = camTransform.position;
        cameraGameObject.transform.rotation = camTransform.rotation;
    }
    #endregion

    #region Setup and Teardown
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        camMoveAction.Enable();
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        camMoveAction.Disable();
    }
    #endregion
}
