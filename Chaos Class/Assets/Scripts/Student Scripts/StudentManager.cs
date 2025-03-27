using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    public bool cooldown = false;
    void Start()
    {
        
    }
    public IEnumerator Cooldown(float time)
    {
        cooldown = true; // Set cooldown to true
        yield return new WaitForSeconds(time); // Wait for 'time' seconds
        cooldown = false; // Reset cooldown
        Debug.Log("Cooldown ended. You can interact again.");
    }
}
