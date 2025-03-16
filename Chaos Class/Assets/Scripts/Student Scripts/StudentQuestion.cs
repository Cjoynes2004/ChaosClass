using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentQuestion : MonoBehaviour
{
    private bool isEmoting = false;
    private int chance = 1000;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        studentPrompt();
    }

    void studentPrompt()
    {
        Vector3 test = new Vector3(1, 10, 1);
        Vector3 test1 = new Vector3(1, 1, 10);
        if (!isEmoting)
        {
            if (Random.Range(1, chance) == 1)
            {
                isEmoting = true;
                if (Random.Range(1, 3)  == 1)
                {
                    transform.localScale = test;
                }
                else
                {
                    transform.localScale = test1;
                }
                
            }
        }
    }
}
