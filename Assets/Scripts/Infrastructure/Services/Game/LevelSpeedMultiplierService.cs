using Infrastructure.StateMachine;
using System.Transactions;
using UniRx;
using UnityEngine;
using System;

public class LevelSpeedMultiplierService : IResettable, ILevelSpeed
{
    public float LevelSpeed { get; set;}
    private readonly LevelPreferences _levelPreferences;
    private readonly CompositeDisposable _disposables = new ();

    public LevelSpeedMultiplierService(LevelPreferences levelPreferences)
    {
        _levelPreferences = levelPreferences;
    }

    public void Start()
    {
        Observable
            .Timer(TimeSpan.FromSeconds(_levelPreferences.TimerSpeed))
            .Repeat()
            .Subscribe(speed => LevelSpeed *= _levelPreferences.SpeedIncreaser)
            .AddTo(_disposables);
    }
    public void Stop()
    {
        _disposables.Clear();
    }
    public void CustomReset()
    {
        LevelSpeed = 1;
    }
}
