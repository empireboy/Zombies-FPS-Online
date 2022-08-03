using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Enemy Settings", menuName = "FPS/Enemy Settings")]
public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
{
    public EnemySettings enemySettings;

    public override void InstallBindings()
    {
        BindSetting(enemySettings.healthSettings);
        BindSetting(enemySettings.selfDamageMultiplierSettings);
    }

    private void BindSetting<T>(T instance)
    {
        Container.Bind<T>()
            .FromInstance(instance)
            .AsSingle();
    }

    [Serializable]
    public class EnemySettings
    {
        public Health.Settings healthSettings;
        public DamageMultiplier.Settings selfDamageMultiplierSettings;
    }
}