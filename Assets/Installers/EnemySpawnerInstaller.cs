using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    [SerializeField] private float _spawnCooldown;

    [SerializeField] private Bootstrap _bootstrap;

    [SerializeField] private SpawnSettingConfig _spawnSettingConfig;
    public override void InstallBindings()
    {
        Container.Bind<Bootstrap>().FromInstance(_bootstrap).AsSingle();
        Container.Bind<SpawnSettingConfig>().FromInstance(_spawnSettingConfig).AsSingle();
        Container.Bind<EnemyFactory>().AsSingle();
        Container.Bind<EnemySpawner>().AsSingle();
    }
}
