using Mirror;
using Runtime.GameLogic.Player;
using UnityEngine;

namespace Runtime.GameLogic
{
   public class Finish : NetworkBehaviour
   {
      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.TryGetComponent(out PlayerData playerData))
         {
            playerData.PlayerReady = false;
            playerData.PlayerMovement.StopMove();

            if (playerData.Score > playerData.AnotherPlayerScore)
               playerData.UIService.ShowWinScreen();
            else if (playerData.Score < playerData.AnotherPlayerScore)
               playerData.UIService.ShowLoseScreen();
            else
               playerData.UIService.ShowWDrawScreen();
         }
      }
   }
}