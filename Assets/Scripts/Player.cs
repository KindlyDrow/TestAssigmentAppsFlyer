using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform m_centerOfMassTransform;
    [SerializeField] private float m_jumpForce;
    private bool isEasyJump;

    private Rigidbody m_playerRb;

    private void Awake()
    {
        m_playerRb = GetComponent<Rigidbody>();
        m_playerRb.centerOfMass = Vector3.Scale(m_centerOfMassTransform.localPosition, transform.localScale);
    }

    private void Start()
    {
        GameInput.Instance.OnTouchStarted += GameInput_OnTouchStarted;
        isEasyJump = DifficultySetings.Instance.IsEasyJump;
    }

    private void GameInput_OnTouchStarted()
    {
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
            GameManager.Instance.GetPoint(pointing.GetPointValue());
        }

        if (other.TryGetComponent<IDamaging>(out  IDamaging idamaging))
        {
            GameManager.Instance.ReceiveDamage();
        }
    }
}
