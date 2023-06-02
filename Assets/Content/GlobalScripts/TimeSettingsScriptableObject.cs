using UnityEngine;

namespace Hydroponical.Settings
{
    [CreateAssetMenu(fileName = "TimeSettings", menuName = "ScriptableObjects/TimeSettings")]
    public class TimeSettingsScriptableObject : ScriptableObject
    {
        [field: SerializeField, Range(0, 24)]
        public float TimeOfDay { get; set; }
        [field: SerializeField]
        public float TimeScale { get; set; } = 1.0f;
        [field: SerializeField]
        public float HourRange { get; set; } = 24.0f;
    }
}