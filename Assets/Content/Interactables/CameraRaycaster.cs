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
                IInteractable hitInteractable = hit.transform.GetComponent<IInteractable>();

                if (CurrentlyHitInteractable != hitInteractable)
                {
                    SetCurrentlyHitInteractable(hitInteractable, true);
                }
                else if (hitInteractable == null)
				{
                    SetCurrentlyHitInteractable(null, false);
                }
            }
            else
			{
                SetCurrentlyHitInteractable(null, false);
			}
        }

        private void SetCurrentlyHitInteractable (IInteractable hitInteractable, bool isHit)
		{
            CurrentlyHitInteractable = hitInteractable;
            GlobalActions.NotifyOnInteractableRaycast(isHit);
        }
    }
}