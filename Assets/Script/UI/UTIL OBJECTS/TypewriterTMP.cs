using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TypewriterTMP : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float delay = 0.05f;
    private string fullText;

    private Coroutine typingCoroutine;

    public UnityEvent OnTypingComplete;



    private void OnEnable()
    {
        StartCoroutine(waitGameManager());
    }

    private void OnDisable()
    {
        GameManager.Instance.OnQuizChanged -= SendAndWriteText;
    }

    private IEnumerator waitGameManager()
    {
        while (GameManager.Instance == null)
        {
            yield return null;
        }
        GameManager.Instance.OnQuizChanged += SendAndWriteText;
    }
    private void SendAndWriteText(Quizz quiz)
    {
        SendAndWriteText(quiz.questionText);
    }



    public void SendAndWriteText(string text)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        fullText = text;
        typingCoroutine = StartCoroutine(TypeText());
    }



    private IEnumerator TypeText()
    {
        textComponent.text = "";
        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(delay);
        }

        typingCoroutine = null;
        OnTypingComplete.Invoke();
    }


}
