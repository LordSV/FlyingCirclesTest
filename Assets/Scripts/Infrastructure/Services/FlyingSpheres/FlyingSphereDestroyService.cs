using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSphereDestroyService 
{
    private readonly LevelStatsService _levelStatsService;
    private readonly FlyingSpheresHolderService _flyingSpheresHolderService;
    private readonly ImpactSpawnService _impactSpawnService;

    public FlyingSphereDestroyService(LevelStatsService levelStatsService, FlyingSpheresHolderService flyingSpheresHolderService, ImpactSpawnService impactSpawnService)
    {
        _levelStatsService = levelStatsService;
        _flyingSpheresHolderService = flyingSpheresHolderService;
        _impactSpawnService = impactSpawnService;
    }

    public void FlyingSphereDestroy(FlyingSphere sphere)
    {
        _levelStatsService.Score.Value++;
        _levelStatsService.Points += sphere.FlyingSphereDataHolder.Points;
        _flyingSpheresHolderService.Remove(sphere.FlyingSphereDataHolder);
        _impactSpawnService.Spawn(sphere.FlyingSphereDataHolder.Transform.position);
    }
}
