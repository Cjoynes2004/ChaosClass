using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform cameraTransform; 
    public MeshFilter handMeshFilter;
    public MeshRenderer handMeshRenderer;

    private InteractableObject heldObject = null;
    private Mesh defaultHandMesh;
    private Material defaultHandMaterial;

    void Start()
    {
        if (handMeshFilter != null)
            defaultHandMesh = handMeshFilter.mesh; 

        if (handMeshRenderer != null)
            defaultHandMaterial = handMeshRenderer.material;
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

        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                CallOnStudent(true);
            }
            else
            {
                heldObject.Interact();
            }   
        }

        if (Input.GetMouseButtonDown(1))
        {
            CallOnStudent(false);
        }
    }

    void TryPickupObject()
    {
        GameObject target = null;
        target = ReturnPlayerView(2);
        InteractableObject interactable = target.GetComponent<InteractableObject>();

        if (interactable != null)
        {
            heldObject = interactable;
            handMeshFilter.mesh = interactable.objectMesh; 
            handMeshRenderer.material = interactable.objectMaterial; 
            interactable.gameObject.SetActive(false); 
        }

    }

    void DropObject()
    {
        if (heldObject != null)
        {
            handMeshFilter.mesh = defaultHandMesh; 
            handMeshRenderer.material = defaultHandMaterial; 
            heldObject.gameObject.SetActive(true); 
            heldObject.transform.position = cameraTransform.position + cameraTransform.forward * 1f; // Place in front of player
            heldObject = null;
        }
    }

    public GameObject ReturnPlayerView(float viewDistance)
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, viewDistance))
        {
            return hit.collider.gameObject;
        }
        return null;

    }
    
    private void CallOnStudent(bool behavior)
    {
        GameObject student = ReturnPlayerView(10);
        StudentQuestion question = student.GetComponent<StudentQuestion>();
        if (student.GetComponent<StudentQuestion>() != null)
        {
            if ((question.isQuestion && behavior) || (question.isMisbehaving && !behavior))
            {
                question.CalledOn();
            }
            else
            {
                //Add taking away points.
            }
        }
    }
}
