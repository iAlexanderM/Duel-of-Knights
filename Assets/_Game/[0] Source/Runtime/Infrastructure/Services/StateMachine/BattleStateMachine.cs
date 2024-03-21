using System;
using System.Collections.Generic;
using Runtime.Infrastructure.Services.StateMachine.States;

namespace Runtime.Infrastructure.Services.StateMachine
{
   public class BattleStateMachine : IStateMachine
   {
      private readonly Dictionary<Type, IState> _states = new();
      private IState _currentState;

      public void Enter<TState>() where TState : IState
      {
         _currentState?.Exit();
         _currentState = _states[typeof(TState)];
         _currentState.Enter();
      }

      public void Tick()
      {
         _currentState?.Tick();
      }

      public void RegisterState<TState>(TState state) where TState : IState
      {
         if (_states.ContainsKey(typeof(TState)))
            throw new Exception($"State {typeof(TState).Name} already registered");

         _states.Add(typeof(TState), state);
      }
      
      
   }
}