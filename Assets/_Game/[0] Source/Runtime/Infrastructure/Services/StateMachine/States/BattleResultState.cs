namespace Runtime.Infrastructure.Services.StateMachine.States
{
   public class BattleResultState : IState
   {
      private readonly IStateMachine _stateMachine;

      public BattleResultState(IStateMachine stateMachine)
      {
         _stateMachine = stateMachine;
      }

      public void Enter()
      {
      }

      public void Tick()
      {
      }

      public void Exit()
      {
      }
   }
}