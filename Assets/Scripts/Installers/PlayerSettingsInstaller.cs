using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Player Settings", menuName = "FPS/Player Settings")]
public class PlayerSettingsInstaller : ScriptableObjectInstaller<PlayerSettingsInstaller>
{
    public PlayerSettings playerSettings;

    public override void InstallBindings()
    {
        Container.Bind<AxisRotator.Settings>()
            .FromInstance(playerSettings.playerRotationSettings)
            .AsTransient()
            .When(context => context.ConcreteIdentifier.ToString() == "Player Root");

        Container.Bind<AxisRotator.Settings>()
            .FromInstance(playerSettings.headRotationSettings)
            .AsTransient()
            .When(context => context.ConcreteIdentifier.ToString() == "Player Head");

        BindSetting(playerSettings.movementSettings);
        BindSetting(playerSettings.swaySettings);
    }

    private void BindSetting<T>(T instance)
    {
        Container.Bind<T>()
            .FromInstance(instance)
            .AsSingle();
    }

    [Serializable]
    public class PlayerSettings
    {
        public AxisRotator.Settings playerRotationSettings;
        public AxisRotator.Settings headRotationSettings;
        public CharacterControllerMovement.Settings movementSettings;
        public Sway.Settings swaySettings;
    }
}