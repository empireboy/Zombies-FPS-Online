using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Gun Settings", menuName = "FPS/Gun Settings")]
public class GunSettingsInstaller : ScriptableObjectInstaller<GunSettingsInstaller>
{
    public GunSettings gunSettings;

    public override void InstallBindings()
    {
        BindSetting(gunSettings.shootSettings);
    }

    private void BindSetting<T>(T instance)
    {
        Container.Bind<T>()
            .FromInstance(instance)
            .AsSingle();
    }

    [Serializable]
    public class GunSettings
    {
        public RaycastShoot.Settings shootSettings;
    }
}