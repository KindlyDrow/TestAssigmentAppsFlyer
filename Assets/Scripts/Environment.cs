using UnityEngine;

public class Environment : MonoBehaviour
{

    private DifficultySetings difficultySetings;

    private void Start()
    {
        difficultySetings = DifficultySetings.Instance;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * Time.deltaTime * difficultySetings.CurSpeed;
    }

    public void Return()
    {
        EnvironmentFactory.Instance.ReturnEnviroment(gameObject);
    }
}
