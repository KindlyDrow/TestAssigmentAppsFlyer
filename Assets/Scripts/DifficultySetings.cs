using UnityEngine;

public class DifficultySetings : MonoBehaviour
{
    public static DifficultySetings Instance { get; private set; }

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard,
    }

    private Difficulty m_difficulty;

    [System.Serializable]
    private class GameDifficultySetings
    {
        public float speed;
        public bool isEasyJumpOn;
        public int lifeAmount;
    }

    [SerializeField] private GameDifficultySetings m_easyMode;
    [SerializeField] private GameDifficultySetings m_mediumMode;
    [SerializeField] private GameDifficultySetings m_hardMode;


    private GameDifficultySetings m_currentDifficulty;

    public float CurSpeed { get { return m_currentDifficulty.speed; } }
    public bool IsEasyJump { get { return m_currentDifficulty.isEasyJumpOn; } }
    public int InitLifeAmount { get { return m_currentDifficulty.lifeAmount; } }



    private void Awake()
    {
        Instance = this;
        SetDifficulty(Difficulty.Easy);
    }

    private void Start()
    {
        
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                m_currentDifficulty = m_easyMode;
                break;
            case Difficulty.Medium:
                m_currentDifficulty = m_mediumMode;
                break;
            case Difficulty.Hard:
                m_currentDifficulty = m_hardMode;
                break;
        }
        m_difficulty = difficulty;
    }

    public Difficulty GetCurDifficulty()
    {
        return m_difficulty;
    }
}
