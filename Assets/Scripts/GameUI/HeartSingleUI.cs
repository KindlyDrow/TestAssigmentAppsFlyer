using UnityEngine;

public class HeartSingleUI : MonoBehaviour
{
    [SerializeField] private GameObject m_activeHeart;

    public void SetHeartActive()
    {
        m_activeHeart.SetActive(true);
    }

    public void SetHeartDisabled()
    {
        m_activeHeart.SetActive(false);
    }
}
