using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{

    private DifficultySetings difficultySetings;

    private void Start()
    {
        difficultySetings = DifficultySetings.Instance;
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * difficultySetings.CurSpeed;
    }

    public void Return()
    {
        EnvironmentFactory.Instance.ReturnEnviroment(gameObject);
    }
}
