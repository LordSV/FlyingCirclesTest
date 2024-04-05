using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent (typeof(Canvas))]
public class FinishPanelService : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Canvas _canvas;
    private LevelStatsService _levelStatsService;
    private GameLoopStateMachine _gameLoopStateMachine;

    [Inject]
    private void Construct(LevelStatsService levelStatsService, GameLoopStateMachine gameLoopStateMachine)
    {
        _levelStatsService = levelStatsService;
        _gameLoopStateMachine = gameLoopStateMachine;
    }

    public void Show()
    {
        _canvas.enabled = true;
        _scoreText.text = _levelStatsService.Points.ToString("0");
    }

    public void Hide()
    {
        _canvas.enabled = false;
    }

    public void Restart()
    {
        _gameLoopStateMachine.Enter<RestartState>();
    }

}
