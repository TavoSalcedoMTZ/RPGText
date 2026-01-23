using System.Collections;
using TMPro;
using UnityEngine;

public class JudgeUIController : MonoBehaviour
{
    [SerializeField] private JudgeCardUI[] judgeCards;
    [SerializeField] private TextMeshProUGUI finalScoreTMP;
    [SerializeField] private TextMeshProUGUI finalTextTMP;

    [SerializeField] private float delayBetweenJudges = 1.5f;

    private void Start()
    {
        StartCoroutine(ShowJudgement());
    }

    private IEnumerator ShowJudgement()
    {
        var session = JudgementSession.Instance;
        if (session == null) yield break;

        foreach (var card in judgeCards)
            card.Clear();

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < session.JudgeResults.Count && i < judgeCards.Length; i++)
        {
            var result = session.JudgeResults[i];
            var card = judgeCards[i];

            card.SetJudge(result.JudgeName);
            card.SetScore(result.Score);
            card.SetComments(result.Comments);

            yield return new WaitForSeconds(delayBetweenJudges);
        }

        finalScoreTMP.text = $"TOTAL: {session.TotalScore:0.0}";
        finalTextTMP.text = session.FinalText;
    }
}
