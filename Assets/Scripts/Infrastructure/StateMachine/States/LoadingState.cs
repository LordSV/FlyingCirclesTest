using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class LoadingState : State
    {
        public LoadingState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

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
