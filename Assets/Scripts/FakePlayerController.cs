using UnityEngine;
using UnityEngine.InputSystem;


// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// WARNING 
// OC INSERT INBOUND
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

// This script is only temporary lil bro

public class FakePlayerController : MonoBehaviour
{


    private Interactable interactableInteracting;

    [SerializeField]
    private LayerMask interactableLayermask;

    [SerializeField]
    private float interactionRadius = .5f; // like, going, like, Into the Radius (am I right or am I right?)



    [SerializeField]
    private TEMP_InputActions inputActions;
    private InputAction interactAction;



    void OnEnable()
    {
        inputActions = new TEMP_InputActions();

        interactAction = inputActions.Player.Interact;
        interactAction.performed += InteractPerformed;
        interactAction.Enable();
    }
    void OnDisable()
    {
        interactAction.performed -= InteractPerformed;
        interactAction.Disable();
    }

    private void InteractPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Interact Pressed");

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, .5f, Vector2.up, .5f, interactableLayermask);


        if (interactableInteracting != null && interactableInteracting.isInteracting)
        {
            interactableInteracting.Interact(false);

            interactableInteracting = null;

            return;
        }


        foreach (RaycastHit2D hit in hits)
        {
            Interactable i;
            if (hit.collider.gameObject.TryGetComponent<Interactable>(out i))
            {

                interactableInteracting = i;
                interactableInteracting.Interact(true);

                break;
            }
        }
    }

}
