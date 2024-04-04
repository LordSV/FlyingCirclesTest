using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FlyingSpherePool : BasePool<FlyingSphere, FlyingSphereDataHolder>
{
    private readonly DiContainer _diContainer;
    private readonly FlyingSpherePreferences _spherePreferences;
    public FlyingSpherePool(DiContainer diContainer, FlyingSpherePreferences spherePreferences)
    {
        _diContainer = diContainer;
        _spherePreferences = spherePreferences;
    }
    public void Initialize()
    {
        Fill(_spherePreferences.PoolSize, _spherePreferences.SpherePrefab);
    }
    protected override void Activate(FlyingSphereDataHolder obj)
    {
        obj.GameObject.SetActive(true);
    }

    protected override FlyingSphereDataHolder CreateObject(FlyingSphere prefab)
    {
        FlyingSphere sphere = _diContainer.InstantiatePrefabForComponent<FlyingSphere>(prefab);
        FlyingSphereDataHolder sphereDataHolder = new FlyingSphereDataHolder(sphere);
        sphere.FlyingSphereDataHolder = sphereDataHolder;
        return sphereDataHolder;
    }

    protected override void Deactivate(FlyingSphereDataHolder obj)
    {
        obj.GameObject.SetActive(false);
    }
}
