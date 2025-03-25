using UnityEngine;

public class StudentQuestion : MonoBehaviour
{
    public bool isQuestion = false;
    public bool isMisbehaving = false;
    public int chance = 10000;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        studentPrompt();
    }

    void studentPrompt()
    {
        if (!isQuestion && !isMisbehaving)
        {
            if (Random.Range(1, chance) == 1)
            {
                if (Random.Range(1, 3)  == 1)
                {
                    isQuestion = true;
                    animator.SetBool("handRaised", true);
                }
                else
                {
                    isMisbehaving = true;
                    animator.SetBool("isMisbehaving", true);
                }
                
            }
        }
    }

    public void CalledOn()
    {
        isQuestion = false;
        isMisbehaving = false;
        animator.SetBool("handRaised", false);
        animator.SetBool("isMisbehaving", false);
    }
}
