using UnityEngine;
using Zenject;

public class FlyingSphereMoveService : ITickable
{
    private readonly ISpheresHolder _spheresHolder;
    private readonly ILevelSpeed _levelSpeed;

    public FlyingSphereMoveService(ISpheresHolder spheresHolder, ILevelSpeed levelSpeed)
    {
        _spheresHolder = spheresHolder;
        _levelSpeed = levelSpeed;
    }

    public void Tick()
    {
        foreach (FlyingSphereDataHolder holder in _spheresHolder.Get())
        {
            holder.Transform.Translate(Vector3.up * _levelSpeed.LevelSpeed * holder.Speed *  Time.deltaTime);
        }
    }
}
