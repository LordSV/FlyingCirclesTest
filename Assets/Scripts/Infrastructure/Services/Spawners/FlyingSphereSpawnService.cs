using System;
using UniRx;

public class FlyingSphereSpawnService 
{
    private readonly SpawnPreferences _spawnPreferences;
    private readonly FlyingSphereFactory _sphereFactory;
    private readonly ISpheresHolder _spheresHolder;
    private readonly CompositeDisposable _disposables = new();

    public FlyingSphereSpawnService(SpawnPreferences spawnPreferences, FlyingSphereFactory sphereFactory, ISpheresHolder spheresHolder)
    {
        _spawnPreferences = spawnPreferences;
        _sphereFactory = sphereFactory;
        _spheresHolder = spheresHolder;
    }

    public void SpawnStart()
    {
        Observable
            .Timer(TimeSpan.FromSeconds(1 / _spawnPreferences.SpawnAmount))
            .Repeat()
            .Subscribe(spawn => SpawnEntity())
            .AddTo(_disposables);
    }

    private void SpawnStop()
    {
        _disposables.Clear();
    }

    private void SpawnEntity()
    {
        FlyingSphereDataHolder flyingSphere = _sphereFactory.CreateFlyingSphere();
        _spheresHolder.Add(flyingSphere);
    }
}
