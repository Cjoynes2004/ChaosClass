using UnityEngine;

public class StudentQuestion : MonoBehaviour
{
    public bool isQuestion = false;
    public bool isMisbehaving = false;
    public int chance = 1000;
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
        if (!isQuestion && !isMisbehaving)
        {
            if (Random.Range(1, chance) == 1)
            {
                if (Random.Range(1, 3)  == 1)
                {
                    isQuestion = true;
                    transform.localScale = test;
                }
                else
                {
                    isMisbehaving = true;
                    transform.localScale = test1;
                }
                
            }
        }
    }

    public void CalledOn()
    {
        isQuestion = false;
        isMisbehaving = false;
        transform.localScale = new Vector3(1, 1, 1);
    }
}
