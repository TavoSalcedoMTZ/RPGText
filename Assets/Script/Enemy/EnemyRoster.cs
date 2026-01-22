using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRoster : MonoBehaviour
{
    public FoodCommentsDatabase commentsDatabase;

    public UnityEvent<float> OnJudgementFinished;

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
        float totalScore = 0f;

        foreach (var judge in Judges)
        {
            List<string> comments;
            float score = judge.JudgeFood(cookedFood, out comments);
            totalScore += score;

            Debug.Log($"{judge.Name} score: {score:0.0}");

            foreach (var comment in comments)
                Debug.Log(comment);
        }

        OnJudgementFinished?.Invoke(totalScore);
    }
}
