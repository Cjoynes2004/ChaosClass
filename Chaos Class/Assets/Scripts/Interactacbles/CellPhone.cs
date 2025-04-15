using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPhone : InteractableObject
{

    [SerializeField] private Mesh phoneMesh;
    [SerializeField] private Material phoneMaterial;

    public PlayerMovement player;

    public override Mesh objectMesh => phoneMesh;
    public override Material objectMaterial => phoneMaterial;

    public Canvas cellphoneUI;
    public ToggleUI toggler;

    public override void Interact()
    {
        if (!cellphoneUI.isActiveAndEnabled)
        {
            cellphoneUI.gameObject.SetActive(true);
            cellphoneUI.enabled = true;
            player.canMove = false;
            toggler.SwitchUI();
        }      
    }
}
