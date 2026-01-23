using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Quizz currentQuiz;
    public ButtonsController buttonsController;
    public TimerManager timerManager;
    public UIManager uiManager;
    public FoodManager managerCurrentRecipe;


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


        if (_quiz.isFinal)
        {
            JudgeTime();
        }
        else
        {
            OnQuizChanged?.Invoke(currentQuiz);
        }
    }

    public void StartRound()
    {
        uiManager.timerClock.EntryClock();
        timerManager.StartTimerManager();
    }
    public void RoundComplete()
    {
        timerManager.StopTimer();
        uiManager.timerClock.ExitClock();
        
    }

    public void JudgeTime()
    {

    }

    public Quizz GetCurrentQuiz()
    {
        return currentQuiz;
    }

    private void Update()
    {
        if (timerManager != null && timerManager.isTimerRunning)
        {
            uiManager.timerClock.UpdateClock(timerManager.GetNormalizedTime());
        }
    }




}
