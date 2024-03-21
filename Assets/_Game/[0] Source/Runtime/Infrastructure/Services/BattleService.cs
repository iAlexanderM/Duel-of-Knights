using Mirror;
using Runtime.GameLogic.Player;
using Runtime.Infrastructure.Services.StateMachine;
using Runtime.Infrastructure.Services.StateMachine.States;
using UnityEngine;

namespace Runtime.Infrastructure.Services
{
   public class BattleService : NetworkBehaviour
   {
      [SerializeField] private GameObject _propPrefab;
      [SerializeField] private GameObject _finishPrefab;

      private readonly SyncList<PlayerData> _players = new();

      private IStateMachine _stateMachine;

      private void Start()
      {
         InitializeStateMachine();

         _stateMachine.Enter<WaitForPlayersState>();
      }

      private void Update()
      {
         _stateMachine?.Tick();
      }

      private void InitializeStateMachine()
      {
         _stateMachine = new BattleStateMachine();

         _stateMachine.RegisterState(new WaitForPlayersState(_stateMachine, _players, _propPrefab, _finishPrefab));
         _stateMachine.RegisterState(new StartBattleState(_stateMachine, _players));
         _stateMachine.RegisterState(new BattleState(_stateMachine, _players));
         _stateMachine.RegisterState(new BattleResultState(_stateMachine));
      }
   }
}