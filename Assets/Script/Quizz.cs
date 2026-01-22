using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    [TextArea(3, 10)]
    public string DialogueText;
    public AudioClip clipAudio;

}

[CreateAssetMenu(fileName = "Quizz", menuName = "Scriptable Objects/Quizz")]
public class Quizz : ScriptableObject
{
   

    public Dialogue[] dialogo;
    public Option[] options= new Option[2];
    public bool QuizOption;
    public Quizz NextQuiz;

}

[System.Serializable]
public class Option
{
    public string optionText;
    public Quizz NextQuiz;
    public FoodStats statsToAdd;
}