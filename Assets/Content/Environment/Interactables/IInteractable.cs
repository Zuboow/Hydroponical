namespace Hydroponical.Logic.Interactables
{
    public interface IInteractable
    {
        public bool IsCurrentlyInteractable();
        public void Interact ();
    }
}