using System;

namespace Hydroponical
{
	public static class UIActions
	{
		public static Action<int, InventoryType> OnInventoryItemSelection { get; set; }

		public static void NotifyOnInventoryItemSelection (int childIndex, InventoryType type)
		{
			OnInventoryItemSelection.Invoke(childIndex, type);
		}
	}
}