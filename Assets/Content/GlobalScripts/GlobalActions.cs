using System;

namespace Hydroponical
{
    public static class GlobalActions
    {
        public static Action<bool> OnInteractableRaycast { get; set; }

        public static void NotifyOnInteractableRaycast (bool isHitByRaycast)
        {
            OnInteractableRaycast.Invoke(isHitByRaycast);
        }
    }
}