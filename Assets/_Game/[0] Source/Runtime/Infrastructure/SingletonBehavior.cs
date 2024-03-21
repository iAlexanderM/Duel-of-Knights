using UnityEngine;

namespace Runtime.Infrastructure
{
   public class SingletonBehavior<T> : MonoBehaviour where T : class
   {
      public static T Instance;

      public SingletonBehavior() =>
         Instance = this as T;
   }
}