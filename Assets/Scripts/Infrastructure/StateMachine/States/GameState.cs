using Zenject;

namespace Infrastructure.StateMachine.States
{
    public class GameState :State
    {
        private FlyingSphereSpawnService _flyingSphereSpawnService;
        private LevelSpeedMultiplierService _levelSpeedMultiplierService;
        private ClickDetectionService _clickDetectionService;
        private ScoreCounterService _scoreCounterService;
        private CounterTimerService _counterTimerService;
        public GameState(GameLoopStateMachine gameLoopStateMachine) : base(gameLoopStateMachine) { }

        [Inject]
        private void Construct(FlyingSphereSpawnService flyingSphereSpawnService, LevelSpeedMultiplierService levelSpeedMultiplierService, ClickDetectionService clickDetectionService,
            ScoreCounterService scoreCounterService, CounterTimerService counterTimerService)
        { 
            _flyingSphereSpawnService = flyingSphereSpawnService;
            _levelSpeedMultiplierService = levelSpeedMultiplierService;
            _clickDetectionService = clickDetectionService;
            _scoreCounterService = scoreCounterService;
            _counterTimerService = counterTimerService;
        }
        public override void Enter()
        {
            _flyingSphereSpawnService.SpawnStart();
            _levelSpeedMultiplierService.Start();
            _clickDetectionService.StartDetection();
            _scoreCounterService.Show();
            _counterTimerService.StartTimer();
        }

        public override void Exit()
        {
            _flyingSphereSpawnService.SpawnStop();
            _levelSpeedMultiplierService.Stop();
            _clickDetectionService.StopDetection();
            _scoreCounterService.Hide();
        }
    }
}
