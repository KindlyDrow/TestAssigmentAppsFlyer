using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameManager gameManager;
    public override void InstallBindings()
    {
        Container.Bind<GameInput>().FromInstance(gameInput).AsSingle().NonLazy();
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle().NonLazy();
    }
}