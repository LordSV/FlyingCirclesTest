using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class RestartState : State
    {
        private IResettable[] _resettables;
        public RestartState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(IResettable[] resettables)
        {
            _resettables = resettables;
        }
        public override void Enter()
        {
            foreach(IResettable resettable in _resettables) 
            {
                resettable.CustomReset();
            }

            GameLoopStateMachine.Enter<TapToStartState>();
        }

        public override void Exit()
        {

        }
    }
}
