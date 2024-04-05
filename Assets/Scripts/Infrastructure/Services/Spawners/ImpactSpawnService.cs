using System;
using UniRx;
using UnityEngine;

public class ImpactSpawnService 
{
    private const float TimeToReturnInPool = 2f;
    private readonly ImpactPool _impactPool;

    public ImpactSpawnService(ImpactPool impactPool)
    {
        _impactPool = impactPool;
    }

    public void Spawn(Vector3 at)
    {
        GameObject impactObject = _impactPool.Get();
        impactObject.transform.position = at;   
        Observable
            .Timer(TimeSpan.FromSeconds(TimeToReturnInPool))
            .Subscribe(time => _impactPool.Return(impactObject));
    }
}
