using Infrastructure.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSpheresHolderService : IResettable, ISpheresHolder
{
    private readonly FlyingSpherePool _spherePool;
    private readonly List<FlyingSphereDataHolder> _dataHolders = new();

    public FlyingSpheresHolderService(FlyingSpherePool spherePool)
    {
        _spherePool = spherePool;
    }
    public void Add(FlyingSphereDataHolder dataHolder)
    {
        _dataHolders.Add(dataHolder);
    }

    public void CustomReset()
    {
        for(int i = _dataHolders.Count - 1; i >= 0; i--)
        {
            Remove(_dataHolders[i]);
        }
    }

    public IEnumerable<FlyingSphereDataHolder> Get()
    {
        return _dataHolders;
    }

    public void Remove(FlyingSphereDataHolder dataHolder)
    {
        _dataHolders.Remove(dataHolder);
        _spherePool.Return(dataHolder);
    }
}
