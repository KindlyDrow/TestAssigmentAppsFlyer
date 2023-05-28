using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum State
    {
        PreGame,
        InGame,
        EndGame,
    }

    private State m_state;

    public event Action<int> OnScoreChanged;
    public event Action OnPreGameStarted;
    public event Action OnInGameStarted;
    public event Action OnEndGameStarted;

    public delegate void MyEventHandler(int maxLife, int curLife);
    public event MyEventHandler OnLifeChanged;

    [SerializeField] private GameObject m_playerGO;

    private int m_curPoints;
    private int m_maxLifeAmount;
    private int m_curlifeAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeState(State.PreGame);
    }

    public void ChangeState(State state)
    {
        switch (state)
        {
            case State.PreGame:
                Time.timeScale = 0f;
                OnPreGameStarted?.Invoke();
                m_playerGO.SetActive(false);
                break;
            case State.InGame:
                Time.timeScale = 1f;
                OnInGameStarted?.Invoke();
                InitVariables();
                m_playerGO.SetActive(true);
                break;
            case State.EndGame:
                m_playerGO.SetActive(false);
                Time.timeScale = 0f;
                OnEndGameStarted?.Invoke();
                break;
        }
        EndState();
        m_state = state;
    }

    private void EndState()
    {
        switch (m_state)
        {
            case State.PreGame:
                break;
            case State.InGame:
                break;
            case State.EndGame:
                break;
        }
    }

    public bool IsInGame()
    {
        return State.InGame == m_state;
    }

    public void GetPoint(int pointValue)
    {
        m_curPoints += pointValue;
        OnScoreChanged?.Invoke(m_curPoints);
    }

    public void ReceiveDamage()
    {
        m_curlifeAmount--;
        OnLifeChanged?.Invoke(m_maxLifeAmount, m_curlifeAmount);
        if (m_curlifeAmount < 1)
        {
            ChangeState(State.EndGame);
        }
        
    }
    private void InitVariables()
    {
        m_curPoints = 0;
        m_maxLifeAmount = DifficultySetings.Instance.InitLifeAmount;
        m_curlifeAmount = m_maxLifeAmount;
        OnLifeChanged?.Invoke(m_maxLifeAmount, m_curlifeAmount);
    }

    public int GetMaxLife()
    {
        return m_maxLifeAmount;
    }
}
