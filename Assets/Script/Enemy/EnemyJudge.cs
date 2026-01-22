using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyJudge
{
    public string Name;
    public FoodStats Preferences;

    private FoodCommentsDatabase commentsDB;

    public EnemyJudge(string name, FoodCommentsDatabase db)
    {
        Name = name;
        commentsDB = db;
        Preferences = new FoodStats(true);
    }

    public float JudgeFood(FoodStats cookedFood, out List<string> comments)
    {
        comments = new List<string>();
        float score = 0f;

        score += EvaluateStat(FoodStatType.Salado, cookedFood.Salado, Preferences.Salado, comments);
        score += EvaluateStat(FoodStatType.Dulce, cookedFood.Dulce, Preferences.Dulce, comments);
        score += EvaluateStat(FoodStatType.Picante, cookedFood.Picante, Preferences.Picante, comments);
        score += EvaluateStat(FoodStatType.Horneado, cookedFood.Horneado, Preferences.Horneado, comments);

        return score;
    }

    private float EvaluateStat(
        FoodStatType type,
        float cooked,
        float preference,
        List<string> comments)
    {
        float diff = cooked - preference;
        float absDiff = Mathf.Abs(diff);

        float statScore = Mathf.Clamp(10f - absDiff, 0f, 10f);

        if (absDiff >= 6f)
            AddComment(type, CommentTone.Negative, comments);
        else if (absDiff <= 2f)
            AddComment(type, CommentTone.Positive, comments);

        return statScore;
    }

    private void AddComment(
        FoodStatType stat,
        CommentTone tone,
        List<string> comments)
    {
        if (commentsDB == null) return;

        string text = commentsDB.GetRandomComment(stat, tone);

        if (!string.IsNullOrEmpty(text))
            comments.Add($"{Name}: {text}");
    }
}

public static class JudgementTextResolver
{
    public static string GetFinalText(float score)
    {
        if (score < 40)
            return "El silencio es incómodo. Nadie quiere seguir probando.";

        if (score < 70)
            return "Los jueces asienten con dudas. Podría mejorar.";

        if (score < 100)
            return "El platillo es aceptado con respeto.";

        return "Los jueces se levantan. Has cocinado una leyenda.";
    }
}
