using UnityEngine;

public static class GameObjectExtensions
{
    public static void SetActiveOptimized (this GameObject gameObject, bool value)
	{
		if (gameObject.activeSelf != value)
		{
			gameObject.SetActive(value);
		}
	}
}
