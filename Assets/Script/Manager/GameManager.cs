using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Quizz currentQuiz;
    public ButtonsController buttonsController;


    //Evento
    public Action<Quizz> OnQuizChanged;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public void SetQuizz(Quizz _quiz)
    {
        currentQuiz = _quiz;
        OnQuizChanged?.Invoke(currentQuiz);

    }

    public Quizz GetCurrentQuiz()
    {
        return currentQuiz;
    }





}
