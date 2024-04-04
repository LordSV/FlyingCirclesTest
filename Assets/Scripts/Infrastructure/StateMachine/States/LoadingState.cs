using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class LoadingState : State
    {
        private FlyingSpherePool _spherePool;
        private ImpactPool _impactPool;
        public LoadingState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(FlyingSpherePool spherePool, ImpactPool impactPool)
        {
            _spherePool = spherePool;   
            _impactPool = impactPool;
        }
        public override void Enter()
        {
            _spherePool.Initialize();
            _impactPool.Initialize();
            GameLoopStateMachine.Enter<RestartState>();
        }

        public override void Exit()
        {

        }
    }
}
