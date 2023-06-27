using UnityEngine;

namespace Hydroponical.Logic.Interactables
{
	public class InteractableController : MonoBehaviour, IInteractable
	{
		public bool IsCurrentlyInteractable ()
		{
			return true;
		}

		public void Interact ()
		{
			
		}
	}
}