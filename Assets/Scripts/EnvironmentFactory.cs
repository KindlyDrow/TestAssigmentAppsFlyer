using System.Collections.Generic;
using UnityEngine;

public class EnvironmentFactory : MonoBehaviour
{
    public static EnvironmentFactory Instance { get; private set; }

    [SerializeField] private GameObject m_environmentPrefab;
    [SerializeField] private int m_initialEnvironmentPoolSize;
    private List<GameObject> m_environmentPool;

    private void Awake()
    {
        Instance = this;
        CreateEnvironmentPool();
    }

    private void Start()
    {
    }

    private void CreateEnvironmentPool()
    {
        m_environmentPool = new List<GameObject>();

        for (int j = 0; j < m_initialEnvironmentPoolSize; j++)
        {
            GameObject enviroment = Instantiate(m_environmentPrefab);
            enviroment.SetActive(false);
            m_environmentPool.Add(enviroment);
        }
    }


    public GameObject GetEnviroment()
    {
        for (int i = 0; i < m_environmentPool.Count; i++)
        {
            if (!m_environmentPool[i].activeSelf)
            {
                return m_environmentPool[i];
            }
        }

        GameObject enviroment = Instantiate(m_environmentPrefab);
        enviroment.SetActive(false);
        m_environmentPool.Add(enviroment);
        return enviroment;
    }

    public void ReturnEnviroment(GameObject enviromentToReturn)
    {
        enviromentToReturn.SetActive(false);
        enviromentToReturn.transform.SetParent(null);
    }

}