using Mirror;

namespace Runtime.Infrastructure
{
   public class NetworkSingletonBehavior<T> : NetworkBehaviour where T : class
   {
      public static T Instance;

      public NetworkSingletonBehavior() =>
         Instance = this as T;
   }
}