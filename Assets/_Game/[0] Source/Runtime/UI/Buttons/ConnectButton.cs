using System;

namespace Runtime.UI
{
   public class ConnectButton : BehaviourButton
   {
      private void Start()
      {
         if (MyNetworkManager.Instance.SteamLobby is null)
            return;
         
         gameObject.SetActive(false);
      }

      protected override void OnClick() =>
         MyNetworkManager.Instance.StartClient();
   }
}