using UnityEngine;

namespace Hydroponical.Logic.Lighting
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Lighting Preset", menuName = "ScriptableObjects/Lighting Preset")]
    public class LightingPreset : ScriptableObject
    {
        [field: SerializeField]
        public Gradient AmbientColor { get; set; }
        [field: SerializeField]
        public Gradient DirectionalColor { get; set; }
        [field: SerializeField]
        public Gradient FogColor { get; set; }
    }
}