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

    public void SetOption(Option _option)
    {
        Clear();
        showText.text = _option.optionText;
        button.onClick.AddListener(() =>
        {
            GameManager.Instance.SetQuizz(_option.NextQuiz);
            buttonsController.horizontalMove.ToggleExit();
            GameManager.Instance.RoundComplete();
        });


    }
}
