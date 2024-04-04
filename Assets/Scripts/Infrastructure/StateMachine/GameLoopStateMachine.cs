using System;
using System.Collections.Generic;
using Infrastructure.StateMachine.States;
using Sirenix.Utilities;
using Zenject;

namespace Infrastructure.StateMachine
{
    public class GameLoopStateMachine : IInitializable
    {
        public IState ActiveState;
        private readonly DiContainer _diContainer;
        private Dictionary<Type, IState> _states;

        public GameLoopStateMachine(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            _states = new Dictionary<Type, IState>
            {
                { typeof(LoadingState), new LoadingState(this) },
                { typeof(GameState), new GameState(this) },
                { typeof(RestartState), new RestartState(this) },
                { typeof(FinishState), new FinishState(this) }
            };
            _states.ForEach(x => _diContainer.Inject(x.Value));
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            ActiveState?.Exit();

            TState state = GetState<TState>();
            ActiveState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
          _states[typeof(TState)] as TState;
    }
}
