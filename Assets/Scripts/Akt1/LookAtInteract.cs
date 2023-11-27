using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtInteract : MonoBehaviour
{
    
    [SerializeField]GameObject InteractionUI;
    [SerializeField]InputActionAsset inputActions;
    InputAction interactAction;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        interactAction = inputActions.FindActionMap("Interaction").FindAction("interact");
    }

    private void OnEnable()
    {
        interactAction.Enable();
    }
    
    private void OnDisable()
    {
        interactAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if(hitObject.GetComponent<InteractObject>() != null)
            {
                InteractionUI.SetActive(true);
                if(interactAction.ReadValue<float>() > 0.5f)
                {
                    
                    hitObject.GetComponent<InteractObject>().Interact();
                }
                
            }
            else
            {
                InteractionUI.SetActive(false);
            }
        }else
        {
            InteractionUI.SetActive(false);
        }
    }
}
