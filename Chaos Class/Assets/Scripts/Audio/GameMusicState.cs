using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicState : MonoBehaviour
{
    void Start()
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.PlayMainTheme();
        }
    }
}
