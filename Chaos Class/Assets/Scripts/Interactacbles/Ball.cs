using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : InteractableObject
{
    [SerializeField] private Mesh ballMesh;
    [SerializeField] private Material ballMaterial;
    private PlayerInteract player;
    public Rigidbody rb;
    private float throwForce = 10f;


    public override Mesh objectMesh => ballMesh;
    public override Material objectMaterial => ballMaterial;

    public override void Interact()
    {
        player.DropObject();
        Vector3 direction = player.GetPlayerFacingDirection();
        rb.AddForce(direction * throwForce, ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerInteract>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
