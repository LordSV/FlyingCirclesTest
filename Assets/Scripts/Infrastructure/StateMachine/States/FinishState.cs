using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class FinishState : State
    {
        private FinishPanelService _finishPanelService;
        public FinishState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(FinishPanelService finishPanelService)
        {
            _finishPanelService = finishPanelService;
        }
        public override void Enter()
        {
            _finishPanelService.Show();
        }

        public override void Exit()
        {
            _finishPanelService.Hide();
        }
    }
}
