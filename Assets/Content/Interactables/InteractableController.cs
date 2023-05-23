using UnityEngine;

namespace Hydroponical.Logic.Interactables
{
	public class InteractableController : MonoBehaviour, IInteractable
	{
		public void NotifyOnInteractableRaycast (bool isHitByRaycast)
		{
			GlobalActions.NotifyOnInteractableRaycast(isHitByRaycast);
		}

		public void Interact ()
		{
			
		}
	}
}