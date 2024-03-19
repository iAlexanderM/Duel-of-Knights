namespace Runtime.Infrastructure.Services.StateMachine.States
{
   public interface IStateMachine
   {
      void Enter<TState>() where TState : IState;
      void Tick();

      void RegisterState<TState>(TState state) where TState : IState;
   }
}