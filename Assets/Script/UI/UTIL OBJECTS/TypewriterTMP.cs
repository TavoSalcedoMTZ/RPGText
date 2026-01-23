using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TypewriterTMP : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    [Header("Timings")]
    public float writeDelay = 0.05f;
    public float eraseDelay = 0.03f;
    public float waitAfterWrite = 0.8f;

    private Coroutine dialogueCoroutine;

    private Dialogue[] dialogues;
    private int currentDialogueIndex;

    public UnityEvent OnTypingComplete;

    private void OnEnable()
    {
        StartCoroutine(WaitGameManager());
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnQuizChanged -= ReceiveQuiz;
    }

    private IEnumerator WaitGameManager()
    {
        while (GameManager.Instance == null)
            yield return null;

        GameManager.Instance.OnQuizChanged += ReceiveQuiz;
    }

    private void ReceiveQuiz(Quizz quiz)
    {
        if (quiz == null || quiz.dialogo == null || quiz.dialogo.Length == 0)
            return;

        if (dialogueCoroutine != null)
            StopCoroutine(dialogueCoroutine);

        dialogueCoroutine = StartCoroutine(StartNewQuiz(quiz));
    }

    private IEnumerator StartNewQuiz(Quizz quiz)
    {
        // Si ya había texto, se borra SOLO porque llega un nuevo quiz
        if (!string.IsNullOrEmpty(textComponent.text))
            yield return StartCoroutine(EraseText());

        dialogues = quiz.dialogo;
        currentDialogueIndex = 0;

        yield return StartCoroutine(DialogueSequence());
    }

    private IEnumerator DialogueSequence()
    {
        while (currentDialogueIndex < dialogues.Length)
        {
            Dialogue dialogue = dialogues[currentDialogueIndex];

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayDialogue(dialogue.clipAudio);

            yield return StartCoroutine(TypeText(dialogue.DialogueText));

            bool hasNextDialogue = currentDialogueIndex < dialogues.Length - 1;

            if (hasNextDialogue)
            {
                yield return new WaitForSeconds(waitAfterWrite);
                yield return StartCoroutine(EraseText());
            }

            currentDialogueIndex++;
        }

        dialogueCoroutine = null;
        OnTypingComplete.Invoke();
    }

    private IEnumerator TypeText(string text)
    {
        textComponent.text = "";

        foreach (char letter in text)
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(writeDelay);
        }
    }

    private IEnumerator EraseText()
    {
        while (textComponent.text.Length > 0)
        {
            textComponent.text =
                textComponent.text.Substring(0, textComponent.text.Length - 1);

            yield return new WaitForSeconds(eraseDelay);
        }
    }
}
