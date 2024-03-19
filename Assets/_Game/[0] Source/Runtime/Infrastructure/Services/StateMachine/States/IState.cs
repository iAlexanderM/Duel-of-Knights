namespace Runtime.Infrastructure.Services.StateMachine.States
{
   public interface IState
   {
      void Enter();
      void Tick();
      void Exit();
   }
}