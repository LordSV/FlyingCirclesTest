using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindAssetProvider();
        BindLevelStatsService();
        BindFlyingSpheresHolderService();
        BindFlyingSphereDestroyService();
        BindLevelSpeedMultiplierService();
        BindOutScreenPositionService();
        BindOutScreenRemoveService();
        BindFlyingSphereParametresRandomizeService();
        BindFlyingSphereSpawnService();
        BindImpactSpawnService();
        BindFlyingSphereFactory();
        BindFlyingSphereMoveService();
    }

    private void BindAssetProvider()
    {
        Container
            .BindInterfacesAndSelfTo<AssetProvider>()
            .AsSingle();
    }
    private void BindLevelStatsService()
    {
        Container
            .BindInterfacesAndSelfTo<LevelStatsService>()
            .AsSingle();
    }
    private void BindFlyingSpheresHolderService()
    {
        Container
            .BindInterfacesAndSelfTo<FlyingSpheresHolderService>()
            .AsSingle();
    }
    private void BindFlyingSphereDestroyService()
    {
        Container
            .BindInterfacesAndSelfTo<FlyingSphereDestroyService>()
            .AsSingle();
    }
    private void BindLevelSpeedMultiplierService()
    {
        Container
            .BindInterfacesAndSelfTo<LevelSpeedMultiplierService>()
            .AsSingle();
    }
    private void BindOutScreenPositionService()
    {
        Container
            .BindInterfacesAndSelfTo<OutScreenPositionService>()
            .AsSingle();
    }
    private void BindOutScreenRemoveService()
    {
        Container
            .BindInterfacesAndSelfTo<OutScreenRemoveService>()
            .AsSingle();
    }
    private void BindFlyingSphereParametresRandomizeService()
    {
        Container
            .BindInterfacesAndSelfTo<FlyingSphereParametresRandomizeService>()
            .AsSingle();
    }
    private void BindFlyingSphereSpawnService()
    {
        Container
            .BindInterfacesAndSelfTo<FlyingSphereSpawnService>()
            .AsSingle();
    }
    private void BindImpactSpawnService()
    {
        Container
            .BindInterfacesAndSelfTo<ImpactSpawnService>()
            .AsSingle();
    }
    private void BindFlyingSphereFactory()
    {
        Container
            .BindInterfacesAndSelfTo<FlyingSphereFactory>()
            .AsSingle();
    }
    private void BindFlyingSphereMoveService()
    {
        Container
            .BindInterfacesAndSelfTo<FlyingSphereMoveService>()
            .AsSingle();
    }
}
