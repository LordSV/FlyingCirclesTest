using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSphereFactory
{
    private readonly FlyingSpherePool _spherePool;
    private readonly OutScreenPositionService _outScreenPositionService;
    private readonly FlyingSphereParametresRandomizeService _parametresRandomizeService;

    public FlyingSphereFactory(FlyingSpherePool spherePool, OutScreenPositionService outScreenPositionService, FlyingSphereParametresRandomizeService parametresRandomizeService)
    {
        _spherePool = spherePool;
        _outScreenPositionService = outScreenPositionService;
        _parametresRandomizeService = parametresRandomizeService;
    }

    public FlyingSphereDataHolder CreateFlyingSphere()
    {
        FlyingSphereDataHolder sphere = _spherePool.Get();
        _parametresRandomizeService.RandomizeParametres(sphere);
        _outScreenPositionService.SetPosition(sphere);
        return sphere;
    }
}
