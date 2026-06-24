using UnityEngine;
using NaughtyAttributes;

/*****************************************************************************
// File Name :         Interactable.cs
// Author :            Rise and Swine
// Creation Date :     June 23, 2026
//
// Brief Description :  This script will be placed on any object that can be 
                        interacted with
*****************************************************************************/
public class Interactable : MonoBehaviour
{


    [HideInInspector]
    public bool isInteracting = false;


    [SerializeField]
    private GameObject minigameScreenPrefab;

    



    public enum Type { minigame, window }
    [Space(40)]
    [Header("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\nDesigner Variables:\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~")]

    [Tooltip("What should happen with this object is interacted with?")]
    public Type type;





    [Space(20)]
    [Header("Options:")]

    [SerializeField]
    [Tooltip("Should the player be unable to move during this interaction?")]
    private bool shouldFreezeMovement = true;

    [SerializeField]
    [HideIf("shouldFreezeMovement")]
    [Tooltip("Should the player be able to walk away and cancel the interaction?")]
    private bool canWalkAwayCancel = true;





    [Space(20)]
    [Header("Minigame Specific:")]

    [Tooltip("What prefab should pop up when a minigame is pulled up")]
    public GameObject minigame;





    /// <summary>
    /// Handles the player pressing the interact key when this object is in range
    /// </summary>
    /// <param name="interact"> Should the player interact or un-interact </param>
    public void Interact(bool interact)
    {
        isInteracting = interact;

        Debug.Log((interact ? "Started" : "Stopped") + " interacting with \""+gameObject.name+"\"");

    }


}
