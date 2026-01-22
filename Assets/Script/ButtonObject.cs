using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonObject : MonoBehaviour
{
    public TextMeshProUGUI showText;
    private Button button;
    [HideInInspector]
    public ButtonsController buttonsController;

    private void Awake()
    {
        button = GetComponent<Button>();
    }



    public void Clear()
    {
        showText.text = "";
        button.onClick.RemoveAllListeners();
    }

    public void SetOption(int _indexOption, Quizz _quizz)
    {
        Option _option = _quizz.options[_indexOption];

        Clear();
        showText.text = _option.optionText;

        button.onClick.AddListener(() =>
        {
            Quizz nextQuizz =
                _quizz.QuizOption
                ? _quizz.NextQuiz
                : _option.NextQuiz;

            GameManager.Instance.SetQuizz(nextQuizz);
            buttonsController.horizontalMove.ToggleExit();
            GameManager.Instance.RoundComplete();
            GameManager.Instance.managerCurrentRecipe.AddNewStats(_option.statsToAdd);
        });
    }
}
