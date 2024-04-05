using DG.Tweening;
using Infrastructure.StateMachine;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Canvas))]
public class ScoreCounterService : MonoBehaviour, IResettable
{
    private readonly IntReactiveProperty _counter = new(0);
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private float _scaleFactor = 1.2f;
    [SerializeField] private float _scaleDuration = 0.2f;
    [SerializeField] private Canvas _canvas;

    [Inject]
    private void Construct(LevelStatsService levelStatsService)
    {
        levelStatsService.Score
            .Subscribe(score =>
            {
                _counterText.text = score.ToString();
                DOTween.Kill(_counterText);
                _counterText.transform.localScale = Vector3.one;
                _counterText.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration);

            })
            .AddTo(this);
    }

    private void Awake()
    {
        _canvas.enabled = false;
    }

    public void Increase()
    {
        _counter.Value++;
    }

    public void Show()
    {
        _canvas.enabled = true;
    }

    public void Hide()
    {
        _canvas.enabled = false;    
    }

    public void CustomReset()
    {
        _counter.Value = 0;
    }
}
