using Mirror;
using Runtime.GameLogic.Player;
using UnityEngine;

namespace Runtime.GameLogic
{
   public class Obstacle : NetworkBehaviour
   {
      private bool _triggered;

      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.TryGetComponent(out PlayerData player))
         {
            if (_triggered)
               return;

            _triggered = true;
            player.Score -= 1;
         }
      }
   }
}