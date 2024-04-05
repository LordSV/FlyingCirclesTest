using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Canvas))]
public class CounterTimerService : MonoBehaviour, IResettable
{
    private readonly FloatReactiveProperty _timeLeft = new();
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Canvas _canvas;
    private  LevelPreferences _levelPreferences;
    private GameLoopStateMachine _gameLoopStateMachine;

    [Inject]
    private void Construct(LevelPreferences levelPreferences, GameLoopStateMachine gameLoopStateMachine)
    {
        _levelPreferences = levelPreferences;
        _gameLoopStateMachine = gameLoopStateMachine;
    }
    private void Awake()
    {
        _canvas.enabled = false;
        MakeSubscription();
    }

    public void StartTimer()
    {
        _canvas.enabled = true;
        Observable
            .EveryLateUpdate()
            .TakeWhile(time => _timeLeft.Value > 0)
            .Subscribe(
            onNext: time => _timeLeft.Value -= Time.deltaTime,
            onCompleted: () =>
            {
                _gameLoopStateMachine.Enter<FinishState>();
                _canvas.enabled = false;
            })
            .AddTo(this);
    }
    public void CustomReset()
    {
        _timeLeft.Value = _levelPreferences.RoundDuration;
    }

    private void MakeSubscription()
    {
        _timeLeft
            .Subscribe(t => _text.text = t.ToString("0"))
            .AddTo(this);
    }
}
