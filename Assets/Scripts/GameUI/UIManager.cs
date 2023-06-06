using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_preGameUI;
    [SerializeField] private GameObject m_inGameUI;
    [SerializeField] private GameObject m_endGameUI;

    [SerializeField] private Button m_startGameButton;
    [SerializeField] private Button m_restartGameButton;

    [Inject] private GameManager gameManager;

    private void Start()
    {
        HideAll();
        m_preGameUI.SetActive(true); 
        m_startGameButton.onClick.AddListener(StartGame);
        m_restartGameButton.onClick.AddListener(ReStartGame);
        gameManager.OnPreGameStarted += GameManager_OnPreGameStarted;
        gameManager.OnInGameStarted += GameManager_OnInGameStarted;
        gameManager.OnEndGameStarted += GameManager_OnEndGameStarted;
    }

    private void GameManager_OnEndGameStarted()
    {
        HideAll();
        m_endGameUI.SetActive(true);
    }

    private void GameManager_OnInGameStarted()
    {
        HideAll();
        m_inGameUI.SetActive(true);
    }

    private void GameManager_OnPreGameStarted()
    {
        HideAll();
        m_preGameUI.SetActive(true);
    }

    private void StartGame()
    {
        HideAll();
        gameManager.ChangeState(GameManager.State.InGame);
    }
    private void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void HideAll()
    {
        m_preGameUI.SetActive(false);
        m_inGameUI.SetActive(false);
        m_endGameUI.SetActive(false);
    }
}
