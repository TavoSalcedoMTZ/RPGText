using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRoster : MonoBehaviour
{
    public FoodCommentsDatabase commentsDatabase;

    public UnityEvent<JudgeResult> OnJudgeEvaluated;
    public UnityEvent<float, string> OnFinalJudgement;

    public List<EnemyJudge> Judges = new List<EnemyJudge>();

    private void Awake()
    {
        CreateJudges();
    }

    void CreateJudges()
    {
        Judges.Clear();

        Judges.Add(new EnemyJudge("Gordo Ramsi", commentsDatabase));
        Judges.Add(new EnemyJudge("Hasbula", commentsDatabase));
        Judges.Add(new EnemyJudge("Sandro Salinas", commentsDatabase));
    }

    public void JudgeFood(FoodStats cookedFood)
    {
        var session = JudgementSession.Instance;
        if (session == null) return;

        float totalScore = 0f;

        foreach (var judge in Judges)
        {
            List<string> comments;
            float score = judge.JudgeFood(cookedFood, out comments);
            totalScore += score;

            session.JudgeResults.Add(
                new JudgeResult(judge.Name, score, comments)
            );
        }

        session.TotalScore = totalScore;
        session.FinalText = JudgementTextResolver.GetFinalText(totalScore);
    }

}
