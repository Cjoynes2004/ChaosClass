using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform cameraTransform; 
    public MeshFilter handMeshFilter;
    public MeshRenderer handMeshRenderer;
    public QuestionManager questionManager;
    public ScoreManager scoreManager;
    public SFXManager sFXManager;


    private InteractableObject heldObject = null;
    private Mesh defaultHandMesh;
    private Material defaultHandMaterial;
    private Vector3  defaultScale;

    StudentManager studentManager;

    void Start()
    {
        if (handMeshFilter != null)
            defaultHandMesh = handMeshFilter.mesh; 
        if (handMeshRenderer != null)
            defaultHandMaterial = handMeshRenderer.material;
        defaultScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void Awake()
    {
        studentManager = FindObjectOfType<StudentManager>();
    }

    void Update()
    {
        if (!FindObjectOfType<StressMeter>().isGameOver)
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

            if (Input.GetMouseButton(0))
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

            if (Input.GetMouseButton(1))
            {
                if (heldObject == null)
                {
                    CallOnStudent(false);
                }
            }
        }   
    }

    void TryPickupObject()
    {
        GameObject target = null;
        target = ReturnPlayerView(400);
        if (target != null)
        {
            InteractableObject interactable = target.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                heldObject = interactable;
                handMeshFilter.mesh = interactable.objectMesh;
                handMeshRenderer.material = interactable.objectMaterial;
                handMeshFilter.transform.localScale = interactable.transform.lossyScale;

                interactable.gameObject.SetActive(false);
            }
        }
    }

    public void DropObject()
    {
        if (heldObject != null)
        {
            handMeshFilter.mesh = defaultHandMesh; 
            handMeshRenderer.material = defaultHandMaterial;
            handMeshRenderer.transform.localScale = defaultScale;
            heldObject.gameObject.SetActive(true); 
            heldObject.transform.position = cameraTransform.position + cameraTransform.forward * 1f; // Place in front of player
            heldObject = null;
        }
    }

    public GameObject ReturnPlayerView(float viewDistance)
    {
        RaycastHit hit = new RaycastHit();
        if (ReturnIsRaycast(viewDistance, out hit))
        {
            if (hit.collider != null)
            {
                return hit.collider.gameObject;
            }     
        }
        return null;

    }

    public bool ReturnIsRaycast(float viewDistance, out RaycastHit hit)
    {
        return Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, viewDistance);
    }

    public Vector3 GetPlayerFacingDirection()
    {
        return cameraTransform.forward.normalized;
    }

    private void CallOnStudent(bool behavior)
    {
        GameObject student = ReturnPlayerView(1000);
        if (student != null && !studentManager.cooldown)
        {
            StudentQuestion question = student.GetComponent<StudentQuestion>();
            if (student.GetComponent<StudentQuestion>() != null)
            {
                if ((question.isQuestion && behavior) || (question.isMisbehaving && !behavior))
                {
                    if (question.isQuestion)
                    {
                        questionManager.AskQuestion();
                    }
                    else
                    {
                        scoreManager.IncreaseScore(50);
                        sFXManager.PlayReprimand();
                    }

                    question.CalledOn();                     
                }
                else if (question.isMisbehaving || question.isQuestion)
                {
                    //Add taking away points.
                    StartCoroutine(studentManager.Cooldown(5));
                    sFXManager.PlayErrorAudio();
                }
            }
        }
        
    }
}
