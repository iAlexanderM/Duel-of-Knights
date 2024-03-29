using System;
using System.Collections;
using Mirror;
using Runtime.GameLogic.Player;
using UnityEngine;

namespace Runtime.GameLogic
{
   public class PlayerMovement : NetworkBehaviour
   {
      [SerializeField] private Rigidbody2D _rigidbody2D;
      [SerializeField] public PlayerAnimationController AnimationController;

      [Header("Jump Parameters")] [SerializeField]
      private float _jumpForce = 18;

      [SerializeField] private float _gravityScale = 5;
      [SerializeField] private float _fallingGravityScale = 18;

      [Header("Movement Parameters")] [SerializeField]
      private float _movementSpeed = 16;

      private bool _isGrounded;
      private bool _canControl;
      private bool _canMove;

      private void Update()
      {
         if (!isLocalPlayer || !_canMove)
            return;

         Move();

         if (!_canControl)
            return;

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
      public void StartMove()
      {
         _canMove = true;
         _canControl = true;
         AnimationController.PlayRun();
      }

      public void StopMove()
      {
         StartCoroutine(StopMoveRoutine());
         _canControl = false;
      }

      public IEnumerator StopMoveRoutine()
      {
         var delay = new WaitForSeconds(0.2f);
         while (_movementSpeed > 0.1f)
         {
            _movementSpeed = Mathf.Lerp(_movementSpeed, 0, 0.1f);
            yield return delay;
         }

         _canMove = false;
      }
   }
}