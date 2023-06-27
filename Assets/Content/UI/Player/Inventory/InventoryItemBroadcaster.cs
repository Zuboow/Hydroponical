using UnityEngine;

namespace Hydroponical.UI
{
    public class InventoryItemBroadcaster : MonoBehaviour
    {
        [field: SerializeField]
        private InventoryType BroadcastedInventoryType { get; set; }

        public void SelectItem ()
        {
            UIActions.NotifyOnInventoryItemSelection(transform.GetSiblingIndex(), BroadcastedInventoryType);
        }
    }
}