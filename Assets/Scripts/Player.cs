using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_jumpForce;
    private bool isEasyJump;

    private Rigidbody m_playerRb;
    [Inject] private GameInput gameInput;
    [Inject] private GameManager gameManager;

    private void Awake()
    {
        m_playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameInput.OnTouchStarted += GameInput_OnTouchStarted;
        isEasyJump = DifficultySetings.Instance.IsEasyJump;
    }

    private void GameInput_OnTouchStarted()
    {
        if (!gameManager.IsInGame()) { return; }
        if (isEasyJump) 
        { 
            m_playerRb.velocity = Vector3.zero; 
        }
        m_playerRb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IPointing>(out IPointing pointing))
        {
            gameManager.GetPoint(pointing.GetPointValue());
        }

        if (other.TryGetComponent<IDamaging>(out  IDamaging idamaging))
        {
            gameManager.ReceiveDamage();
        }
    }
}
