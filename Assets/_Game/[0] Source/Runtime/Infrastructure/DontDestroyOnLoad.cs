using UnityEngine;

namespace Runtime.Infrastructure
{
   public class DontDestroyOnLoad : MonoBehaviour
   {
      private void Awake() =>
         DontDestroyOnLoad(gameObject);
   }
}