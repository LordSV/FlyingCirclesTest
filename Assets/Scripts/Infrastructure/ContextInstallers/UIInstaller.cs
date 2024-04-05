using Zenject;
using Infrastructure.AssetManagement;

public class UIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindTapToStartService();
        BindLevelTimerService();
        BindScoreCounterService();
        BindFinishPanelService();
    } 

    private void BindTapToStartService()
    {
        Container
            .BindInterfacesAndSelfTo<TapToStartService>()
            .FromComponentInNewPrefabResource(AssetPath.TapToStart)
            .AsSingle();
    }
    private void BindLevelTimerService()
    {
        Container
            .BindInterfacesAndSelfTo<CounterTimerService>()
            .FromComponentInNewPrefabResource(AssetPath.LevelTimer)
            .AsSingle();
    }
    private void BindScoreCounterService()
    {
        Container
            .BindInterfacesAndSelfTo<ScoreCounterService>()
            .FromComponentInNewPrefabResource(AssetPath.ScoreCounter)
            .AsSingle();
    }
    private void BindFinishPanelService()
    {
        Container
            .BindInterfacesAndSelfTo<FinishPanelService>()
            .FromComponentInNewPrefabResource(AssetPath.FinishPanel)
            .AsSingle();
    }
}
