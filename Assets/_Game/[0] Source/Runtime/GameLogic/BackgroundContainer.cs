using System.Collections.Generic;
using Mirror;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.GameLogic
{
   public class BackgroundContainer : NetworkBehaviour
   {
      [SerializeField] private List<Sprite> _bg;
      [SerializeField] private GameObject _emptyPrefab;
      [SerializeField] private int _bgCount;
      [SerializeField] private float _scaleValue;
      [SerializeField] private int _orderLayer;

      [ContextMenu("RandomGeneration")]
      private void RandomGeneration()
      {
         RemoveAllChildrens();
         var position = transform.position;
         var count = 0;

         while (count < _bgCount)
         {
            var id = Random.Range(0, _bg.Count);

            var instance = Instantiate(_emptyPrefab, position, quaternion.identity, transform);
            var spriteRenderer = instance.AddComponent<SpriteRenderer>();
            instance.transform.localScale = Vector3.one * _scaleValue;
            spriteRenderer.sprite = _bg[id];
            spriteRenderer.sortingOrder = _orderLayer;
            position += Vector3.right * spriteRenderer.sprite.bounds.size.x * _scaleValue;

            count++;
         }
      }

      private void RemoveAllChildrens()
      {
         for (int i = 0; i < transform.childCount; i++)
         {
            DestroyImmediate(transform.GetChild(i).gameObject);
         }
      }
   }
}