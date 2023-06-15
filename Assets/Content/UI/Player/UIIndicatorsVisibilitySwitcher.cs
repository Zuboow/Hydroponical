using UnityEngine;

namespace Hydroponical.UI
{
    public class UIIndicatorsVisibilitySwitcher : MonoBehaviour
    {
        [field: SerializeField]
        private Transform InteractableUseIndicator { get; set; }
        [field: SerializeField]
        private Transform Pointer { get; set; }

        protected virtual void Start ()
		{
            InitializeVisibility();
		}

        protected virtual void OnEnable ()
		{
            AttachToEvents();
		}

        protected virtual void OnDisable ()
        {
            DetachFromEvents();
        }

        private void AttachToEvents ()
		{
            GlobalActions.OnInteractableRaycast += SetInteractableUseIndicatorVisibility;
        }

        private void DetachFromEvents ()
        {
            GlobalActions.OnInteractableRaycast -= SetInteractableUseIndicatorVisibility;
        }

        private void SetInteractableUseIndicatorVisibility (bool isVisible)
		{
            InteractableUseIndicator.gameObject.SetActiveOptimized(isVisible);
		}

        private void SetPointerVisibility (bool isVisible)
        {
            Pointer.gameObject.SetActiveOptimized(isVisible);
        }

        private void InitializeVisibility ()
		{
            SetInteractableUseIndicatorVisibility(false);
            SetPointerVisibility(true);
        }
    }
}