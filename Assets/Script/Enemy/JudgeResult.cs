using System.Collections.Generic;

[System.Serializable]
public class JudgeResult
{
    public string JudgeName;
    public float Score;
    public List<string> Comments;

    public JudgeResult(string name, float score, List<string> comments)
    {
        JudgeName = name;
        Score = score;
        Comments = comments;
    }
}
