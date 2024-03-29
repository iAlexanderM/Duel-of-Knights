using System;
using Mirror;
using Runtime.GameLogic.Player;
using UnityEngine;

namespace Runtime.GameLogic
{
   public class Finish : NetworkBehaviour
   {
      [SerializeField] private PlayerAnimationController _playerAnimator;
      [SerializeField] private Animator _animator;

      [SerializeField] private RuntimeAnimatorController[] _controllers;

      public void Init(int id)
      {
         _animator.runtimeAnimatorController = _controllers[id];
         _playerAnimator.PlayRun();
      }

      private void OnTriggerEnter2D(Collider2D other)
      {
         if (other.TryGetComponent(out PlayerData playerData))
         {
            playerData.PlayerMovement.StopMove();

            _playerAnimator.PlayHit();
            playerData.PlayerMovement.AnimationController.PlayHit();

            if (playerData.Score > playerData.AnotherPlayerScore)
            {
               playerData.UIService.ShowWinScreen();
               playerData.PlayerMovement.AnimationController.PlayVictory();
               playerData.AudioService.PlayWin();
            }
            else if (playerData.Score < playerData.AnotherPlayerScore)
            {
               _playerAnimator.PlayVictory();
               playerData.UIService.ShowLoseScreen();
               playerData.AudioService.PlayLose();
            }
            else
            {
               playerData.UIService.ShowWDrawScreen();
               playerData.PlayerMovement.AnimationController.PlayVictory();
            }

            // if (playerData.Score > playerData.AnotherPlayerScore)
            //    playerData.UIService.ShowWinScreen();
            // else if (playerData.Score < playerData.AnotherPlayerScore)
            //    playerData.UIService.ShowLoseScreen();
            // else
            //    playerData.UIService.ShowWDrawScreen();
         }
      }
   }
}