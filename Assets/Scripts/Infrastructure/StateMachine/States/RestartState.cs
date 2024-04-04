using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class RestartState : State
    {
        public RestartState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct()
        {

        }
        public override void Enter()
        {

        }

        public override void Exit()
        {

        }
    }
}
