using System.Collections.Generic;
using UnityEngine;

public class JudgementSession : MonoBehaviour
{
    public static JudgementSession Instance;

    public FoodStats CookedFood;
    public List<JudgeResult> JudgeResults = new List<JudgeResult>();
    public float TotalScore;
    public string FinalText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Clear()
    {
        JudgeResults.Clear();
        TotalScore = 0f;
        FinalText = "";
        CookedFood = null;
    }
}
