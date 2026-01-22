using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyRoster : MonoBehaviour
{
    public List<EnemyJudge> Judges = new List<EnemyJudge>();

    [Header("Events")]
    public UnityEvent<float> OnJudgementFinished;

    private void Awake()
    {
        CreateJudges();
    }

    void CreateJudges()
    {
        Judges.Clear();

        Judges.Add(new EnemyJudge("Gordo Ramsi"));
        Judges.Add(new EnemyJudge("Hasbula"));
        Judges.Add(new EnemyJudge("Sandro Salinas"));
    }

    public void JudgeFood(FoodStats cookedFood)
    {
        float totalScore = 0f;

        foreach (var judge in Judges)
        {
            float score = judge.JudgeFood(cookedFood);
            totalScore += score;

            Debug.Log($"{judge.Name}: {score:0.0} puntos");
        }

        OnJudgementFinished?.Invoke(totalScore);
    }
}
