using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chalk : InteractableObject
{
    [SerializeField] private Mesh chalkMesh;
    [SerializeField] private Material chalkMaterial;

    private PlayerInteract player;

    public override Mesh objectMesh => chalkMesh;
    public override Material objectMaterial => chalkMaterial;

    private void Awake()
    {
        player = FindObjectOfType<PlayerInteract>();
    }

    public override void Interact()
    {
        if (player == null) return;

        if (player.ReturnIsRaycast(10, out RaycastHit hit))
        {
            Chalkboard chalkboard = hit.collider.GetComponent<Chalkboard>();

            if (chalkboard != null)
            {
                Debug.Log($"Drawing at {hit.textureCoord}");
                chalkboard.Draw(hit.textureCoord);
            }
        }
    }
}
