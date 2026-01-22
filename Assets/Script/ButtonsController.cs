using System.Collections;
using TMPro;
using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    public HorizontalMove horizontalMove;
    public ButtonObject[] buttonObjects;


    public void Awake()
    {
        foreach (var button in buttonObjects)
        {
            button.buttonsController=this;
        }

    }

    private void OnEnable()
    {
        StartCoroutine(waitGameManager());
    }
    private void OnDisable()
    {
        GameManager.Instance.OnQuizChanged -= LoadOption;
    }
    private IEnumerator waitGameManager()
    {
        while (GameManager.Instance == null)
        {
            yield return null;
        }
        GameManager.Instance.OnQuizChanged += LoadOption;
    }

    public void LoadOption(Quizz currentQuiz)
    {

        if (currentQuiz == null) { return; }

        for (int i = 0; i < buttonObjects.Length; i++)
        {
            if (i < currentQuiz.options.Length)
            {
                buttonObjects[i].SetOption(i, currentQuiz);
                buttonObjects[i].gameObject.SetActive(true);
            }
            else
            {
                buttonObjects[i].Clear();
                buttonObjects[i].gameObject.SetActive(false);
            }
        }

    }




    public void PressRandomButton()
    {
        if (buttonObjects.Length == 0) { return; }
        int randomIndex = Random.Range(0, buttonObjects.Length);
       // Debug.Log("Botones leght" + buttonObjects.Length + " Random index: " + randomIndex);
        buttonObjects[randomIndex].GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
    }


    






} 
