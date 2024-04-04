using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private int TargetFPS = 60;
    private GameLoopStateMachine _gameLoopStateMachine;

    [Inject]
    private void Construct(GameLoopStateMachine gameLoopStateMachine) =>
        _gameLoopStateMachine = gameLoopStateMachine;

    private void Awake()
    {
        Application.targetFrameRate = TargetFPS;

    }

    private void Start()
    {
        _gameLoopStateMachine.Enter<LoadingState>();
    }
}
