using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Game Settings", menuName = "FPS/Game Settings")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public GameSettings gameSettings;

    public override void InstallBindings()
    {
        BindSetting(gameSettings.enemySpawnManagerSettings);
    }

    private void BindSetting<T>(T instance)
    {
        Container.Bind<T>()
            .FromInstance(instance)
            .AsSingle();
    }

    [Serializable]
    public class GameSettings
    {
        public EnemySpawnManager.Settings enemySpawnManagerSettings;
    }
}