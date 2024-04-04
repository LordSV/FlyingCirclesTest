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
            Container.BindInterfacesAndSelfTo<GameLoopStateMachine>().AsSingle();
        }
    }
}

