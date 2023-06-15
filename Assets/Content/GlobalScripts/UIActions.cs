using System;

namespace Hydroponical
{
	public static class UIActions
	{
		public static Action<int> OnInventoryItemSelection { get; set; }

		public static void NotifyOnInventoryItemSelection (int childIndex)
		{
			OnInventoryItemSelection.Invoke(childIndex);
		}
	}
}