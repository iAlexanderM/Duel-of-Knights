using Mirror;
using UnityEngine;

namespace Runtime.GameLogic.Camera
{
   public class CameraController : NetworkBehaviour
   {
      [SerializeField] private GameObject _cameraHolder;
      [SerializeField] private GameObject _audioListener;

      public override void OnStartAuthority()
      {
         _cameraHolder.SetActive(true);
         _audioListener.SetActive(true);
      }
   }
}