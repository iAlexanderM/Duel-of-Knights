using System.Collections.Generic;
using System.Linq;
using Mirror;
using Runtime.GameLogic.Player;
using Runtime.GameLogic.Props;
using UnityEngine;

namespace Runtime.Infrastructure.Services.StateMachine.States
{
   public class WaitForPlayersState : IState
   {
      private readonly IStateMachine _stateMachine;
      private readonly SyncList<PlayerData> _players;
      private readonly GameObject _propPrefab;
      private GameObject _finishPrefab;
      private readonly GameObject _syncPrefab;

      public WaitForPlayersState(IStateMachine stateMachine, SyncList<PlayerData> players, GameObject propPrefab, GameObject finishPrefab)
      {
         _stateMachine = stateMachine;
         _players = players;
         _propPrefab = propPrefab;
         _finishPrefab = finishPrefab;
      }

      public void Enter()
      {
         Debug.Log("WaitForPlayersState");
         SpawnProps();
      }

      public void Tick()
      {
         if (NetworkServer.connections.Count == NetworkServer.maxConnections)
         {
            if (NetworkServer.connections.Values.Any(conn => conn.identity is null))
               return;

            InitializePlayers();

            if (_players.Count == NetworkServer.maxConnections)
               _stateMachine.Enter<StartBattleState>();
         }
      }

      public void Exit()
      {
      }

      private void InitializePlayers()
      {
         foreach (var connection in NetworkServer.connections.Values)
         {
            var player = connection.identity.GetComponent<PlayerData>();
            _players.Add(player);
         }
      }
      
      [Server]
      private void SpawnProps()
      {
         var factory = new ObstacleFactory();
         factory.RandomGeneration(_propPrefab, _finishPrefab, new Vector2(5, .5f), new Vector2(5, -19.5f));
      }
   }
}