using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject m_conversionDataUI;
    [SerializeField] private GameObject m_preGameUI;
    [SerializeField] private GameObject m_inGameUI;
    [SerializeField] private GameObject m_endGameUI;

    [SerializeField] private Button m_startGameButton;
    [SerializeField] private Button m_okButton;
    [SerializeField] private Button m_restartGameButton;

    private void Start()
    {
        HideAll();
        m_conversionDataUI.SetActive(true); 
        m_startGameButton.onClick.AddListener(StartGame);
        m_restartGameButton.onClick.AddListener(ReStartGame);
        m_okButton.onClick.AddListener(() =>
        {
            HideAll();
            m_preGameUI.SetActive(true);
        });
        GameManager.Instance.OnPreGameStarted += GameManager_OnPreGameStarted;
        GameManager.Instance.OnInGameStarted += GameManager_OnInGameStarted;
        GameManager.Instance.OnEndGameStarted += GameManager_OnEndGameStarted;
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
        GameManager.Instance.ChangeState(GameManager.State.InGame);
    }
    private void ReStartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void HideAll()
    {
        m_conversionDataUI.SetActive(false);
        m_preGameUI.SetActive(false);
        m_inGameUI.SetActive(false);
        m_endGameUI.SetActive(false);
    }
}
