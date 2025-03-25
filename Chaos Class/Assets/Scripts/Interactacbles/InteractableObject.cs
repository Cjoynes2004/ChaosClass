using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public  abstract Mesh objectMesh { get; }
    public abstract Material objectMaterial { get; }
    public  abstract void Interact();
}
