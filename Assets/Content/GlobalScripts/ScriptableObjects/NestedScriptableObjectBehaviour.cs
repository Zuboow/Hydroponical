using UnityEngine;

namespace Hydroponical
{
    public class NestedScriptableObjectBehaviour : MonoBehaviour
    {
        [field: SerializeField]
        private ScriptableObject ScriptableObjectToNest { get; set; } = null;
        public ScriptableObject CurrentScriptableObject => ScriptableObjectToNest;
    }
}