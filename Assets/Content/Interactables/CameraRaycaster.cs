using UnityEngine;
using Hydroponical.Logic.Interactables;

namespace Hydroponical.UI
{
    public class CameraRaycaster : MonoBehaviour
    {
        [field: SerializeField]
        private float RaycastDistance { get; set; } = 2.0f;

        private IInteractable CurrentlyHitInteractable { get; set; }

        protected virtual void Update ()
        {
            RaycastTowards();
        }

        private void RaycastTowards ()
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, RaycastDistance) == true)
            {
                CurrentlyHitInteractable = hit.transform.GetComponent<IInteractable>();

                if (CurrentlyHitInteractable != null)
                {
                    CurrentlyHitInteractable.NotifyOnInteractableRaycast(true);
                }
            }
            else if (CurrentlyHitInteractable != null)
			{
                CurrentlyHitInteractable.NotifyOnInteractableRaycast(false);
                CurrentlyHitInteractable = null;
			}
        }
    }
}