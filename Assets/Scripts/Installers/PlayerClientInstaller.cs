using Aura2API;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Zenject;

public class PlayerClientInstaller : MonoInstaller
{
    [SerializeField]
    private AuraCamera _auraCamera;

    [SerializeField]
    private PostProcessLayer _postProcessLayer;

    [SerializeField]
    private Camera _camera;

    public override void InstallBindings()
    {
        DisableCamera();

        Container.Bind<PlayerSpawner>().AsSingle();
    }

    private void DisableCamera()
    {
        Destroy(_auraCamera);
        Destroy(_postProcessLayer);
        Destroy(_camera);
    }
}