using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicState : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.PlayMenuTheme();
        }
    }
}
