using UnityEngine;

public class StudentQuestion : MonoBehaviour
{
    public StressMeter stressMeter;
    public bool isQuestion = false;
    public bool isMisbehaving = false;
    private int chance = 10000;
    public SFXManager sound;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sound = FindAnyObjectByType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        studentPrompt();
        if (isQuestion || isMisbehaving) 
        {
            stressMeter.IncreaseStress((float)(0.01 * Time.deltaTime));
        }
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
                    sound.PlayQuestion();
                }
                else
                {
                    isMisbehaving = true;
                    animator.SetBool("misbehaving", true);
                    sound.PlayMisbehave();
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
