using System;
using System.Collections;
using Mirror;
using Runtime.Infrastructure.Networking;
using Runtime.UI;
using UnityEngine;

namespace Runtime.GameLogic.Player
{
   public class PlayerData : NetworkBehaviour
   {
      [SyncVar] private int _score;
      public int AnotherPlayerScore { get; private set; }

      public int Score
      {
         get => _score;
         set
         {
            _score = value;
            StartCoroutine(OnDataChanged());
         }
      }

      private void Start()
      {
         AudioService = AudioService.Instance;
      }

      [HideInInspector] public bool PlayerReady;

      public UIService UIService;

      public PlayerMovement PlayerMovement;
      public AudioService AudioService;

      public int PlayerId { get; set; }
      public Animator Animator;


      [Command]
      private void SetDataToServer()
      {
         ServerData.Instance.UpdateData(PlayerId, _score);
      }

      [ClientRpc]
      public void SetData(int anotherPlayerScore)
      {
         AnotherPlayerScore = anotherPlayerScore;
      }

      private IEnumerator OnDataChanged()
      {
         if (!isLocalPlayer)
            yield break;

         yield return new WaitForSeconds(0.15f);
         SetDataToServer();
      }
   }
}