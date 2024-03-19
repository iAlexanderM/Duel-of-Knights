namespace Runtime.UI
{
   public class HostServerButton : BehaviourButton
   {
      protected override void OnClick()
      {
         if (MyNetworkManager.Instance.SteamLobby is null)
         {
            MyNetworkManager.Instance.StartHost();
            return;
         }

         MyNetworkManager.Instance.SteamLobby.HostLobby();
      }
   }
}