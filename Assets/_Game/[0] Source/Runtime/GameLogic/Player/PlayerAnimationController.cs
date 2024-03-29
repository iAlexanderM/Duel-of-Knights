using Mirror;
using UnityEngine;

namespace Runtime.GameLogic.Player
{
   public class PlayerAnimationController : NetworkBehaviour
   {
      [SerializeField] private Animator _animator;

      private static readonly int Run = Animator.StringToHash("Run");
      private static readonly int Hit = Animator.StringToHash("Hit");
      private static readonly int Victory = Animator.StringToHash("Victory");

      private void Awake()
      {
         _animator = GetComponent<Animator>();
      }

      [ContextMenu("PlayRun")]
      public void PlayRun()
      {
         _animator.SetBool(Run, true);
      }

      [ContextMenu("PlayHit")]
      public void PlayHit()
      {
         _animator.SetBool(Hit, true);
      }

      [ContextMenu("PlayVictory")]
      public void PlayVictory()
      {
         _animator.SetBool(Victory, true);
      }
   }
}