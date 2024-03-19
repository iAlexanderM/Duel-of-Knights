using Mirror;
using UnityEngine;

namespace Runtime.GameLogic.Camera
{
   public class CameraController : NetworkBehaviour
   {
      [SerializeField] private GameObject _cameraHolder;

      public override void OnStartAuthority() =>
         _cameraHolder.SetActive(true);
   }
}