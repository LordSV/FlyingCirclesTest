using Infrastructure.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindClickDetectionService();
        }

        private void BindGameStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameLoopStateMachine>().AsSingle();
        }
        private void BindClickDetectionService()
        {
            Container.BindInterfacesAndSelfTo<ClickDetectionService>().AsSingle();
        }
    }
}
