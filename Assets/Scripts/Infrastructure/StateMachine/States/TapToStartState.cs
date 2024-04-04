using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class TapToStartState : State
    {
        private TapToStartService _tapToStartService;
        public TapToStartState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(TapToStartService tapToStartService)
        {
            _tapToStartService = tapToStartService;
        }
        public override void Enter()
        {
            _tapToStartService.Show();
        }

        public override void Exit()
        {
            _tapToStartService.Hide();
        }
    }
}
