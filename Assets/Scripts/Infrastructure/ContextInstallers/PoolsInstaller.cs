using Zenject;

public class PoolsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindFlyingSpheresPool();
        BindImpactPool();
    }

    private void BindFlyingSpheresPool()
    {
        Container
            .BindInterfacesAndSelfTo<FlyingSpherePool>()
            .AsSingle();
    }
    private void BindImpactPool()
    {
        Container
            .BindInterfacesAndSelfTo<ImpactPool>()
            .AsSingle();
    }
}
