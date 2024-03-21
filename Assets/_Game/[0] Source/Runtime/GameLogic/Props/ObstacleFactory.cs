using Mirror;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Runtime.GameLogic.Props
{
   public class ObstacleFactory
   {
      private float _minDistance = 5f;
      private float _maxDistance = 10f;
      private int _propCount = 10;

      public void RandomGeneration(GameObject propPrefab, GameObject finishPrefab, Vector2 fistStartPosition,
         Vector2 secondStartPosition)
      {
         var firstLastPosition = fistStartPosition;
         var secondLastPosition = secondStartPosition;

         for (int i = 0; i < _propCount; i++)
         {
            var offset = Random.Range(_minDistance, _maxDistance);

            firstLastPosition += Vector2.right * offset;
            secondLastPosition += Vector2.right * offset;

            var firstInstance = Object.Instantiate(propPrefab, firstLastPosition, Quaternion.identity);
            var secondInstance = Object.Instantiate(propPrefab, secondLastPosition, Quaternion.identity);

            NetworkServer.Spawn(firstInstance);
            NetworkServer.Spawn(secondInstance);
         }
         
         firstLastPosition += Vector2.right * _maxDistance;
         secondLastPosition += Vector2.right * _maxDistance;

         var firstFinishInstance = Object.Instantiate(finishPrefab, firstLastPosition, Quaternion.identity);
         var secondFinishInstance = Object.Instantiate(finishPrefab, secondLastPosition, Quaternion.identity);

         NetworkServer.Spawn(firstFinishInstance);
         NetworkServer.Spawn(secondFinishInstance);
      }
   }
}