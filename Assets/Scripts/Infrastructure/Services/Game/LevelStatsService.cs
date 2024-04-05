using Infrastructure.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class LevelStatsService : IResettable
{
    public readonly IntReactiveProperty Score = new();
    public float Points;
    public void CustomReset()
    {
        Score.Value = 0;
        Points = 0;
    }
}
