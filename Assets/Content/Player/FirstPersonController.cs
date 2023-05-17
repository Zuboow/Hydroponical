using UnityEngine;
using UnityEngine.InputSystem;

namespace Hydroponical.Logic.Player
{
	public class FirstPersonController : MonoBehaviour
	{
		[field: SerializeField]
		private float PlayerSpeed { get; set; } = 3.0f;
		[field: SerializeField]
		private float PlayerSprintMultiplier { get; set; } = 1.6f;
		[field: SerializeField]
		private float PlayerJumpForce { get; set; } = 12.0f;
		[field: SerializeField]
		private float GravityScale { get; set; } = 9.81f;
		[field: SerializeField]
		private float FallSpeedScale { get; set; } = 0.2f;
		[field: SerializeField]
		private CharacterController PlayerCharacterController { get; set; }

		private PlayerActions PlayerActionsComponent { get; set; }
		private bool IsSprinting { get; set; } = false;

		private Vector3 playerVelocity;

		protected virtual void Awake ()
		{
			InitializePlayerActions();
		}

		protected virtual void OnEnable ()
		{
			PlayerActionsComponent.Movement.Enable();
			AttachToEvents();
		}

		protected virtual void OnDisable ()
		{
			PlayerActionsComponent.Movement.Disable();
			DetachFromEvents();
		}

		protected virtual void AttachToEvents ()
		{
			PlayerActionsComponent.Movement.Jump.started += Jump;
			PlayerActionsComponent.Movement.Sprint.started += StartSprinting;
			PlayerActionsComponent.Movement.Sprint.canceled += StopSprinting;
		}

		protected virtual void DetachFromEvents ()
		{
			PlayerActionsComponent.Movement.Jump.started -= Jump;
			PlayerActionsComponent.Movement.Sprint.started -= StartSprinting;
			PlayerActionsComponent.Movement.Sprint.canceled -= StopSprinting;
		}

		protected virtual void Update ()
		{
			MovePlayer();
		}

		private void MovePlayer ()
		{
			Vector3 moveInput = PlayerActionsComponent.Movement.Move.ReadValue<Vector2>();
			playerVelocity.y += -GravityScale * Time.deltaTime;
			float speedMultiplier = PlayerSpeed * (IsSprinting == true && PlayerCharacterController.isGrounded == true ? PlayerSprintMultiplier : 1.0f);

			PlayerCharacterController.Move(((transform.right * moveInput.x + transform.forward * moveInput.y) * speedMultiplier + playerVelocity) * Time.deltaTime);
		}

		private void Jump (InputAction.CallbackContext callback)
		{
			if (PlayerCharacterController.isGrounded == true)
			{
				playerVelocity.y = Mathf.Sqrt(PlayerJumpForce * -FallSpeedScale * -GravityScale);
			}
		}

		private void StartSprinting (InputAction.CallbackContext callback)
		{
			IsSprinting = true;
		}

		private void StopSprinting (InputAction.CallbackContext callback)
		{
			IsSprinting = false;
		}

		private void InitializePlayerActions ()
		{
			PlayerActionsComponent = new PlayerActions();
		}
	}
}