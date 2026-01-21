using UnityEngine;

[CreateAssetMenu(fileName = "Quizz", menuName = "Scriptable Objects/Quizz")]
public class Quizz : ScriptableObject
{
    [TextArea(3, 10)]
    public string questionText;
    public Option[] options= new Option[2];

}

[System.Serializable]
public class Option
{
    public string optionText;
    public Quizz NextQuiz;
}