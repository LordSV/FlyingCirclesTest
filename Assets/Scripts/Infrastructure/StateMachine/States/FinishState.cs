using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class FinishState : State
    {
        public FinishState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

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
