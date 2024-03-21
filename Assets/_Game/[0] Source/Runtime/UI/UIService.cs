using System.Collections;
using Mirror;
using Runtime.GameLogic.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI
{
   public class UIService : NetworkBehaviour
   {
      [SerializeField] private TMP_Text _text;
      [SerializeField] private Image _bg;
      [SerializeField] private PlayerData _playerData;


      [ClientRpc]
      public void Countdown()
      {
         StartCoroutine(CountdownRoutine());
      }

      public void ShowLoseScreen()
      {
         _text.text = "YOU LOSE";
         _bg.gameObject.SetActive(true);
      }

      public void ShowWinScreen()
      {
         _text.text = "YOU WIN";
         _bg.gameObject.SetActive(true);
      }

      public void ShowWDrawScreen()
      {
         _text.text = "DRAW";
         _bg.gameObject.SetActive(true);
      }

      private IEnumerator CountdownRoutine()
      {
         var delay = new WaitForSeconds(1f);

         _text.text = "3";
         yield return delay;
         _text.text = "2";
         yield return delay;
         _text.text = "1";
         yield return delay;
         _text.text = "GO!";
         yield return delay;

         _bg.gameObject.SetActive(false);
         _playerData.PlayerReady = true;
      }
   }
}