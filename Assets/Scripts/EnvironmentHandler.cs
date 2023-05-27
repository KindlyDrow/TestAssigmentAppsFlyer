using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    [SerializeField] private int m_initStartPosSize;
    [SerializeField] private float m_initDistanceToStart;
    [SerializeField] private float m_initDistanceBetween;

    [SerializeField] private float maxYPos;

    private void Start()
    {
        for (int i = 0; i < m_initStartPosSize; i++)
        {
            SpawnEnvironment(m_initDistanceBetween * i + m_initDistanceToStart);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Environment>(out Environment environment))
        {
            SpawnEnvironment(other.transform.position.x + m_initStartPosSize * m_initDistanceBetween);

            environment.Return();
        }
    }

    private void SpawnEnvironment(float xPos)
    {
        Vector3 spawnPos;
        float randomYPos = Random.Range(-maxYPos, maxYPos);
        spawnPos = new Vector3(xPos, randomYPos, 0);

        GameObject environmentGO = EnvironmentFactory.Instance.GetEnviroment();
        environmentGO.transform.position = spawnPos;
        environmentGO.SetActive(true);
    }
}
