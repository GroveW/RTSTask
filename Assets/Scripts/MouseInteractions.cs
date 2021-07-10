using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInteractions : MonoBehaviour
{
    new private Camera camera;
    
    [SerializeField]
    private LayerMask interactionsMask;

    private Interactable currentlyInteracting = null;

    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        CheckRaycast();
    }

    void CheckRaycast()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out hit, 1000f, interactionsMask))
        {
            currentlyInteracting = hit.collider.GetComponent<Interactable>();
        }
        else if (currentlyInteracting)
        {
            currentlyInteracting = null;
        }
    }

    public void HandleMouseClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Debug.Log("Click");
        }
    }
}
