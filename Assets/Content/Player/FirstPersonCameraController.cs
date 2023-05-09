using UnityEngine;
using UnityEngine.InputSystem;

namespace Hydroponical.Logic.Player
{
    public class FirstPersonCameraController : MonoBehaviour
    {
        [field: SerializeField]
        private float MouseSensitivity { get; set; }
        [field: SerializeField]
        private Transform PlayerTransform { get; set; }

		private float MinXRotation { get; set; } = -90.0f;
		private float MaxXRotation { get; set; } = 90.0f;
		private float XRotation { get; set; } = 0.0f;
		private PlayerActions PlayerActionsComponent { get; set; }

		protected virtual void Awake ()
		{
			InitializePlayerActions();
		}

		protected virtual void Start ()
		{
            SetCursorLockState();
		}

		protected virtual void OnEnable ()
		{
			PlayerActionsComponent.Camera.Enable();
			AttachToEvents();
		}

		protected virtual void OnDisable ()
		{
			PlayerActionsComponent.Camera.Disable();
			DetachFromEvents();
		}

		protected virtual void AttachToEvents ()
		{
			PlayerActionsComponent.Camera.Mouse.performed += MoveCamera;
		}

		protected virtual void DetachFromEvents ()
		{
			PlayerActionsComponent.Camera.Mouse.performed -= MoveCamera;
		}

		private void MoveCamera (InputAction.CallbackContext callback)
		{
			Vector2 mouseMovement = callback.ReadValue<Vector2>() * MouseSensitivity * Time.deltaTime;

			XRotation -= mouseMovement.y;
			XRotation = Mathf.Clamp(XRotation, MinXRotation, MaxXRotation);

			transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
			PlayerTransform.Rotate(Vector3.up * mouseMovement.x);
		}

        private void SetCursorLockState ()
		{
            Cursor.lockState = CursorLockMode.Locked;
        }

		private void InitializePlayerActions ()
		{
			PlayerActionsComponent = new PlayerActions();
		}
	}
}