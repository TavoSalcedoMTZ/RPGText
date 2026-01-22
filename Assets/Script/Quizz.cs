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

}

[System.Serializable]
public class Option
{
    public string optionText;
    public Quizz NextQuiz;
}