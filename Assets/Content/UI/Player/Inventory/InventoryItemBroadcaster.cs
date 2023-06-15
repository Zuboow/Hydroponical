using UnityEngine;

namespace Hydroponical.UI
{
    public class InventoryItemBroadcaster : MonoBehaviour
    {
        public void SelectItem ()
        {
            UIActions.NotifyOnInventoryItemSelection(transform.GetSiblingIndex());
        }
    }
}