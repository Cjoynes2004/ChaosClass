using UnityEngine;

public class StudentQuestion : MonoBehaviour
{
    public bool isQuestion = false;
    public bool isMisbehaving = false;
    private int chance = 10000;
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
                Debug.Log($"{this.name} should be animating");

                if (Random.Range(1, 3)  == 1)
                {
                    isQuestion = true;
                    animator.SetBool("handRaise", true);
                }
                else
                {
                    isMisbehaving = true;
                    animator.SetBool("misbehaving", true);
                }
                
            }
        }
    }

    public void CalledOn()
    {
        isQuestion = false;
        isMisbehaving = false;
        animator.SetBool("handRaise", false);
        animator.SetBool("misbehaving", false);
    }
}
