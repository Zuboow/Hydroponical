namespace Hydroponical.Logic.Interactables
{
    public interface IInteractable
    {
        public void Interact ();
        public void NotifyOnInteractableRaycast (bool isHitByRaycast);
    }
}