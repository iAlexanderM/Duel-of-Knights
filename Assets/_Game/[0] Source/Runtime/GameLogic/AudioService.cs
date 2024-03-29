using Mirror;
using Runtime.Infrastructure;
using UnityEngine;

namespace Runtime.GameLogic
{
   
   public class AudioService : SingletonBehavior<AudioService>
   {
      [SerializeField] private AudioSource _audioSource;
      [SerializeField] private AudioClip _winCLip;
      [SerializeField] private AudioClip _loseCLip;


      public void PlayWin()
      {
         _audioSource.PlayOneShot(_winCLip);
      }

      public void PlayLose()
      {
         _audioSource.PlayOneShot(_loseCLip);
      }
   }
}