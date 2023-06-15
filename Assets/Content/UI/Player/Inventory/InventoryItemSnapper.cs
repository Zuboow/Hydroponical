using UnityEngine;

namespace Hydroponical.UI
{
    public class InventoryItemSnapper : MonoBehaviour
    {
        [field: SerializeField]
        private RectTransform OptionsContainer { get; set; }
        [field: SerializeField]
        private float ScrollSpeed { get; set; } = 1.0f;
        [field: SerializeField]
        private float MinPivotClamp { get; set; } = 0.2f;
        [field: SerializeField]
        private float MaxPivotClamp { get; set; } = 0.8f;

        private float TargetPivot { get; set; } = 0.5f;

        protected virtual void OnEnable ()
        {
            AttachToEvents();
        }

        protected virtual void OnDisable ()
		{
            DetachFromEvents();
		}

        protected virtual void Update ()
        {
            ScrollToItem();
        }

        private void AttachToEvents ()
        {
            UIActions.OnInventoryItemSelection += SnapToItem;
        }

        private void DetachFromEvents ()
        {
            UIActions.OnInventoryItemSelection -= SnapToItem;
        }

        private void SnapToItem (int childIndex)
		{
            TargetPivot = Mathf.Clamp(1.0f - (childIndex / ((float)OptionsContainer.childCount - 1)), MinPivotClamp, MaxPivotClamp);
        }

        private void ScrollToItem ()
		{
            float newPivot = Mathf.Lerp(OptionsContainer.pivot.y, TargetPivot, ScrollSpeed * Time.deltaTime);
            OptionsContainer.pivot = new Vector2(0.0f, newPivot);
		}
    }
}