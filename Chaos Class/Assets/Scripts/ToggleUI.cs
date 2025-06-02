using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
   public TMP_Text crosshair;
   public bool isCrosshair = true;
   public bool noDrop = false;
    public bool noCall = false;
   public void SwitchUI()
    {
        Cursor.visible = !(Cursor.visible);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        crosshair.gameObject.SetActive(!isCrosshair);
        isCrosshair = !isCrosshair;
        noDrop = !noDrop;
        noCall = !noCall;
    }
}
