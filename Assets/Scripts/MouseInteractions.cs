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

    private Interactable interactableChosen = null;

    public Interactable InteractableChosen { get => interactableChosen; set => interactableChosen = value; }

    private void Start()
    {
        camera = Camera.main;

        GameObject.Find("ActionPanel").SetActive(false);
        GameObject.Find("InfoPanel").SetActive(false);
    }

    void Update()
    {
        CheckRaycast();
    }

    void CheckRaycast()
    {
        Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        bool raycastHitTarget = Physics.Raycast(ray, out RaycastHit hit, 1000f, interactionsMask);

        Interactable interactingTmp = null;

        if (raycastHitTarget)
        {
            interactingTmp = hit.collider.GetComponent<Interactable>();
        }

        if (interactingTmp != currentlyInteracting)
        {
            if (currentlyInteracting)
            {
                currentlyInteracting.SetDisabled();
            }

            currentlyInteracting = interactingTmp;

            if (currentlyInteracting)
            {
                currentlyInteracting.SetEnabled();
            }
        }
    }

    public void HandleMouseClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && currentlyInteracting)
        {
            interactableChosen = currentlyInteracting;
            currentlyInteracting.ShowPanel();
        }
    }
}
