using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Infrastructure
{
   public class EntryPoint : MonoBehaviour
   {
      private void Start()
      {
         SceneManager.LoadScene("[1] Lobby");
      }
   }
}