using System;
using Mirror;
using Runtime.Infrastructure;
using UnityEngine;

namespace Runtime.GameLogic
{
   public class PlayerMovement : NetworkBehaviour
   {
      [SerializeField] private Rigidbody2D _rigidbody2D;

      [Header("Jump Parameters")] [SerializeField]
      private float _jumpForce = 18;

      [SerializeField] private float _gravityScale = 5;
      [SerializeField] private float _fallingGravityScale = 18;

      [Header("Movement Parameters")] [SerializeField]
      private float _movementSpeed = 10;
      
      private bool _isGrounded;
      private bool _canControl;

      private void Update()
      {
         if (!isLocalPlayer || !_canControl)
            return;

         Move();
         Jump();
      }

      private void Jump()
      {
         if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
         {
            _rigidbody2D.AddForce(new Vector2(_rigidbody2D.velocity.x, _jumpForce), ForceMode2D.Impulse);
         }

         ChangeGravityScale();
      }

      private void Move()
      {
         _rigidbody2D.velocity = new Vector2(_movementSpeed, _rigidbody2D.velocity.y);
      }


      private void OnCollisionEnter2D(Collision2D other)
      {
         if (other.gameObject.TryGetComponent(out Ground ground))
         {
            _isGrounded = true;
         }
      }

      private void OnCollisionExit2D(Collision2D other)
      {
         if (other.gameObject.TryGetComponent(out Ground ground))
            _isGrounded = false;
      }

      private void ChangeGravityScale()
      {
         if (_rigidbody2D.velocity.y >= 0)
         {
            _rigidbody2D.gravityScale = _gravityScale;
         }
         else if (_rigidbody2D.velocity.y < 0)
         {
            _rigidbody2D.gravityScale = _fallingGravityScale;
         }
      }

      [ClientRpc]
      public void StartMove() =>
         _canControl = true;
      
      public void StopMove() =>
         _canControl = false;
   }
}