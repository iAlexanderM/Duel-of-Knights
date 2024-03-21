using System.Linq;
using Mirror;
using Runtime.GameLogic.Player;
using UnityEngine;

namespace Runtime.Infrastructure.Services.StateMachine.States
{
   public class StartBattleState : IState
   {
      private readonly IStateMachine _stateMachine;
      private readonly SyncList<PlayerData> _players;

      public StartBattleState(IStateMachine stateMachine, SyncList<PlayerData> players)
      {
         _stateMachine = stateMachine;
         _players = players;
      }

      public void Enter()
      {
         Debug.Log("StartBattleState");
         ShowUIToPlayers();
      }

      public void Tick()
      {
         if (!_players.All(p => p.PlayerReady))
            return;
         
         _stateMachine.Enter<BattleState>();
      }

      public void Exit()
      {
      }
      
      private void ShowUIToPlayers()
      {
         foreach (var player in _players)
         {
            player.UIService.Countdown();
         }
      }
   }
}