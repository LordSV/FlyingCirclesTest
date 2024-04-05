using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class LevelStartButton : MonoBehaviour, IPointerDownHandler
{
    private GameLoopStateMachine _gameLoopStateMachine;

    [Inject]
    private void Construct(GameLoopStateMachine gameLoopStateMachine)
    {
        _gameLoopStateMachine = gameLoopStateMachine;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _gameLoopStateMachine.Enter<GameState>();
    }
}
