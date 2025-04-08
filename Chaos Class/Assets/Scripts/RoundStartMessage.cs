using UnityEngine;
using System.Collections;

public class RoundStartMessage : MonoBehaviour
{
    public GameObject roundTextUI;
    public float messageDuration = 5.0f; //Configurable
    public float fadeDuration = 1.0f;    //Time it takes to fade out

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = roundTextUI.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = roundTextUI.AddComponent<CanvasGroup>();
        }

        StartCoroutine(ShowRoundBeginMessage());
    }

    IEnumerator ShowRoundBeginMessage()
    {
        roundTextUI.SetActive(true);
        canvasGroup.alpha = 1;

        yield return new WaitForSeconds(messageDuration);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        roundTextUI.SetActive(false);
    }
}