using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : InteractableObject
{
    [SerializeField] private Mesh ballMesh;
    [SerializeField] private Material ballMaterial;

    public override Mesh objectMesh => ballMesh;
    public override Material objectMaterial => ballMaterial;

    public override void Interact()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
