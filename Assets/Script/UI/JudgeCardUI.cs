using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JudgeCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTMP;
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private TextMeshProUGUI commentsTMP;

    public void Clear()
    {
        nameTMP.text = "";
        scoreTMP.text = "";
        commentsTMP.text = "";
    }

    public void SetJudge(string name)
    {
        nameTMP.text = name;
    }

    public void SetScore(float score)
    {
        scoreTMP.text = $"Puntuación: {score:0.0}";
    }

    public void SetComments(List<string> comments)
    {
        commentsTMP.text = comments == null || comments.Count == 0
            ? "Sin comentarios."
            : string.Join("\n", comments);
    }
}
