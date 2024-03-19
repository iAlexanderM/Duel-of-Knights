using System;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.UI
{
   public class BehaviourButton : MonoBehaviour
   {
      private Button _button;

      private void Awake() =>
         _button = GetComponent<Button>();

      private void OnEnable() =>
         _button.onClick.AddListener(OnClick);

      private void OnDisable() =>
         _button.onClick.RemoveAllListeners();

      protected virtual void OnClick()
      {
      }
   }
}