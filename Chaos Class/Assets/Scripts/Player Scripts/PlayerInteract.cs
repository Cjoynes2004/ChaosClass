using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform cameraTransform; // Assign the player's camera in the Inspector
    public float interactDistance = 2f;
    public MeshFilter handMeshFilter; // MeshFilter of the hand model
    public MeshRenderer handMeshRenderer; // MeshRenderer of the hand model

    private InteractableObject heldObject = null;
    private Mesh defaultHandMesh;
    private Material defaultHandMaterial;

    void Start()
    {
        if (handMeshFilter != null)
            defaultHandMesh = handMeshFilter.mesh; // Store the default hand mesh

        if (handMeshRenderer != null)
            defaultHandMaterial = handMeshRenderer.material; // Store the default material
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }
    }

    void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactDistance))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                heldObject = interactable;
                handMeshFilter.mesh = interactable.objectMesh; // Change hand model
                handMeshRenderer.material = interactable.objectMaterial; // Change hand material
                interactable.gameObject.SetActive(false); // Hide object in world
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            handMeshFilter.mesh = defaultHandMesh; // Restore default hand model
            handMeshRenderer.material = defaultHandMaterial; // Restore default material
            heldObject.gameObject.SetActive(true); // Show the object again
            heldObject.transform.position = cameraTransform.position + cameraTransform.forward * 1f; // Place in front of player
            heldObject = null;
        }
    }
}
