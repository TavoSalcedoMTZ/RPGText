

using UnityEngine;

[System.Serializable]
public class EnemyJudge
{
    public string Name;
    public FoodStats Preferences;

    public EnemyJudge(string name)
    {
        Name = name;
        Preferences = new FoodStats(true); // gustos random
    }

    public float JudgeFood(FoodStats cookedFood)
    {
        if (cookedFood == null) return 0f;

        float score = 0f;

        score += Compare(cookedFood.Salado, Preferences.Salado);
        score += Compare(cookedFood.Dulce, Preferences.Dulce);
        score += Compare(cookedFood.Picante, Preferences.Picante);
        score += Compare(cookedFood.Horneado, Preferences.Horneado);

        return score;
    }

    private float Compare(float cooked, float preference)
    {
        float diff = UnityEngine.Mathf.Abs(cooked - preference);
        return Mathf.Clamp(10f - diff, 0f, 10f);
    }
}
