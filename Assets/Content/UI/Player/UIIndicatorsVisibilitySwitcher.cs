using TMPro;
using UnityEngine;

namespace Hydroponical.UI
{
    public class UIIndicatorsVisibilitySwitcher : MonoBehaviour
    {
        [field: SerializeField]
        private TextMeshProUGUI InteractableUseIndicator { get; set; }

        protected virtual void OnEnable ()
		{
            GlobalActions.OnInteractableRaycast += SetInteractableUseIndicatorVisibility;
		}

        protected virtual void OnDisable ()
        {
            GlobalActions.OnInteractableRaycast -= SetInteractableUseIndicatorVisibility;
        }

        private void SetInteractableUseIndicatorVisibility (bool isVisible)
		{
            InteractableUseIndicator.gameObject.SetActive(isVisible);
		}
    }
}