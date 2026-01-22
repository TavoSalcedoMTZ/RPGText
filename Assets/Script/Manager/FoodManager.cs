using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public FoodStats currentStats;

    public void AddNewStats(FoodStats stats)
    {
        currentStats.AddStats(stats);
    }

}
