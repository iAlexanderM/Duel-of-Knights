using System.Linq;
using Mirror;
using Runtime.GameLogic.Player;
using UnityEngine;

namespace Runtime.Infrastructure.Services.StateMachine.States
{
   public class BattleState : IState
   {
      private readonly IStateMachine _stateMachine;
      private readonly SyncList<PlayerData> _players;

      public BattleState(IStateMachine stateMachine, SyncList<PlayerData> players)
      {
         _stateMachine = stateMachine;
         _players = players;
      }

      public void Enter()
      {
         Debug.Log("BattleState");
         
         foreach (var player in _players)
            player.PlayerMovement.StartMove();
      }

      public void Tick()
      {
         if(_players.Any(p => !p.PlayerReady))
            return;
         
         _stateMachine.Enter<BattleResultState>();
      }

      public void Exit()
      {
      }

      private void StartMove()
      {
         foreach (var player in _players)
         {
            player.PlayerMovement.StartMove();
         }
      }
   }
}