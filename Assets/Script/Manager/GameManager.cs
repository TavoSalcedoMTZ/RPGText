using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Quizz currentQuiz;
    public ButtonsController buttonsController;
    public TimerManager timerManager;
    public UIManager uiManager;
    public FoodManager managerCurrentRecipe;

    public UnityEvent OnJudgeTimeStarted;

    public EnemyRoster enemyRoster;

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
        // Detener gameplay
        timerManager.StopTimer();
        uiManager.timerClock.ExitClock();

        // Crear sesión si no existe
        if (JudgementSession.Instance == null)
            new GameObject("JudgementSession").AddComponent<JudgementSession>();

        // Limpiar y guardar stats finales
        JudgementSession.Instance.Clear();
        JudgementSession.Instance.CookedFood = managerCurrentRecipe.currentStats;

        // Ejecutar juicio (solo cálculo)
        enemyRoster.JudgeFood(managerCurrentRecipe.currentStats);

        OnJudgeTimeStarted.Invoke();
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
