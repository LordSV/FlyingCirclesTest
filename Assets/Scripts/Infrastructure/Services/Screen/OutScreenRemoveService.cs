using Zenject;
using System.Collections.Generic;
using UnityEngine;

public class OutScreenRemoveService : ITickable
{
    private readonly ISpheresHolder _spheresHolder;
    private readonly float _upBorder;

    public OutScreenRemoveService(ISpheresHolder spheresHolder)
    {
        _spheresHolder = spheresHolder;
        float orthographicSize = Camera.main.orthographicSize;
        _upBorder = orthographicSize;
    }

    public void Tick()
    {
        List<FlyingSphereDataHolder> spheresToRemove = GetSpheresToRemove();
        RemoveSpheres(spheresToRemove);
    }

    private List<FlyingSphereDataHolder> GetSpheresToRemove()
    {
        List<FlyingSphereDataHolder> spheresToRemove = new List<FlyingSphereDataHolder>();
        foreach(FlyingSphereDataHolder holder in _spheresHolder.Get())
        {
            float borderSpheresPoint = holder.Transform.position.y - holder.Radius;
            if(borderSpheresPoint > _upBorder)
            {
                spheresToRemove.Add(holder);
            }
        }
        return spheresToRemove;
    }

    private void RemoveSpheres(List<FlyingSphereDataHolder> spheresToRemove)
    {
        for(int i = spheresToRemove.Count - 1; i >= 0; i--)
        {
            _spheresHolder.Remove(spheresToRemove[i]);
        }
    }


}
