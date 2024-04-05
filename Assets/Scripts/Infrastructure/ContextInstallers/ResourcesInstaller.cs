using Infrastructure.AssetManagement;
using Zenject;

public class ResourcesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindFlyingSpherePreferences();
        BindSpawnPreferences();
        LevelPreferences();
    }

    private void BindFlyingSpherePreferences()
    {
        Container
            .BindInterfacesAndSelfTo<FlyingSpherePreferences>()
            .FromResource(AssetPath.FlyingSpherePreferences)
            .AsSingle();
    }
    private void BindSpawnPreferences()
    {
        Container
            .BindInterfacesAndSelfTo<SpawnPreferences>()
            .FromResource(AssetPath.SpawnPreferences)
            .AsSingle();
    }
    private void LevelPreferences()
    {
        Container
            .BindInterfacesAndSelfTo<LevelPreferences>()
            .FromResource(AssetPath.LevelPreferences)
            .AsSingle();
    }
}

