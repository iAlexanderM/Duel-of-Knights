using System.Collections.Generic;
using System.Linq;
using Mirror;
using Runtime.GameLogic.Player;
using UnityEngine;

namespace Runtime.Infrastructure.Networking
{
   public class ServerData : NetworkSingletonBehavior<ServerData>
   {
      private readonly SyncDictionary<int, int> _playersScore = new();

      public void SetActualData()
      {
         Debug.Log("---- SETTING ACTUAL DATA ---");
         foreach (var pair in _playersScore)
         {
            Debug.Log($"Key - {pair.Key}, Value - {pair.Value}");
         }

         foreach (var connection in NetworkServer.connections.Values)
         {
            var id = connection.connectionId;
            var anotherPlayerScore = _playersScore.FirstOrDefault(p => p.Key != id).Value;

            connection.identity.GetComponent<PlayerData>().SetData(anotherPlayerScore);
         }
      }
      
      public void UpdateData(int key, int value)
      {
         _playersScore[key] = value;
         SetActualData();
      }
   }
}