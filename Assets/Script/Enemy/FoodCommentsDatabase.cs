using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "FoodCommentsDatabase",
    menuName = "RPG/Food/Comments Database"
)]
public class FoodCommentsDatabase : ScriptableObject
{
    public List<FoodCommentEntry> comments = new List<FoodCommentEntry>();

    public string GetRandomComment(FoodStatType stat, CommentTone tone)
    {
        List<FoodCommentEntry> pool = new List<FoodCommentEntry>();

        foreach (var entry in comments)
        {
            if (entry.statType == stat && entry.tone == tone)
                pool.Add(entry);
        }

        if (pool.Count == 0)
            return string.Empty;

        return pool[Random.Range(0, pool.Count)].text;
    }
}

[System.Serializable]
public class FoodCommentEntry
{
    public FoodStatType statType;
    public CommentTone tone;

    [TextArea(2, 4)]
    public string text;
}
