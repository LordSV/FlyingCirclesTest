using Zenject;
using Infrastructure.AssetManagement;

public class UIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindTapToStart();
        BindLevelTimer();
        BindScoreCounter();
        BindFinishPanel();
    } 

    private void BindTapToStart()
    {
        Container
            .BindInterfacesAndSelfTo<TapToStartService>()
            .FromComponentInNewPrefabResource(AssetPath.TapToStart)
            .AsSingle();
    }
    private void BindLevelTimer()
    {
        Container
            .BindInterfacesAndSelfTo<CounterTimerService>()
            .FromComponentInNewPrefabResource(AssetPath.LevelTimer)
            .AsSingle();
    }
    private void BindScoreCounter()
    {
        Container
            .BindInterfacesAndSelfTo<ScoreCounterService>()
            .FromComponentInNewPrefabResource(AssetPath.ScoreCounter)
            .AsSingle();
    }
    private void BindFinishPanel()
    {
        Container
            .BindInterfacesAndSelfTo<FinishPanelService>()
            .FromComponentInNewPrefabResource(AssetPath.FinishPanel)
            .AsSingle();
    }
}
