using TMPro;
using UnityEngine;
using Zenject;

public class InGameUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI m_scoreValueText;
    [SerializeField] private Transform m_lifesAmountContainer;
    [SerializeField] private Transform m_lifesAmountTemplate;

    [Inject] private GameManager gameManager;

    private void Start()
    {
        m_scoreValueText.text = "0";
        gameManager.OnScoreChanged += GameManager_OnScoreChanged;
        gameManager.OnLifeChanged += GameManager_OnLifeChanged;
        ChangeLifeAmount(gameManager.GetMaxLife(), gameManager.GetMaxLife());
    }

    private void GameManager_OnLifeChanged(int maxLife, int curLife)
    {
        ChangeLifeAmount(maxLife, curLife);
    }

    private void GameManager_OnScoreChanged(int obj)
    {
        m_scoreValueText.text = obj.ToString();
    }

    private void ChangeLifeAmount(int maxLife, int curLife)
    {
        foreach (Transform child in m_lifesAmountContainer)
        {
            if (child == m_lifesAmountTemplate) continue;
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxLife; i++)
        {
            GameObject singleInfoGO = Instantiate(m_lifesAmountTemplate.gameObject, m_lifesAmountContainer);
            singleInfoGO.SetActive(true);
            if (curLife > 0)
            {
                singleInfoGO.GetComponent<HeartSingleUI>().SetHeartActive();
                curLife--;
            }
            else
            {
                singleInfoGO.GetComponent<HeartSingleUI>().SetHeartDisabled();
            }
        }
    }
}
