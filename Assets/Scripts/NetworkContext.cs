using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Zenject;
using System.Linq;

public class NetworkContext : NetworkBehaviour
{
    [SerializeField]
    private MonoInstaller[] _monoInstallersOwner;

    [SerializeField]
    private MonoInstaller[] _monoInstallersClient;

    [SerializeField]
    private GameObjectContext _gameObjectContext;

    public override void OnNetworkSpawn()
    {
        IEnumerable<MonoInstaller> monoInstallers = _gameObjectContext.Installers;
        List<MonoInstaller> monoInstallersList = monoInstallers.ToList();

        if (IsOwner)
            monoInstallersList.AddRange(_monoInstallersOwner);
        else
            monoInstallersList.AddRange(_monoInstallersClient);

        _gameObjectContext.Installers = monoInstallersList;

        _gameObjectContext.Run();
    }
}