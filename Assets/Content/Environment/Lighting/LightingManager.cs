using UnityEngine;

namespace Hydroponical.Logic.Lighting
{
    [ExecuteAlways]
    public class LightingManager : MonoBehaviour
    {
        [field: SerializeField]
        private Light DirectionalLight { get; set; }
        [field: SerializeField]
        private LightingPreset Preset { get; set; }
        [field: SerializeField, Range(0, 24)]
        private float TimeOfDay { get; set; }
        [field: SerializeField]
        private float TimeScale { get; set; } = 1.0f;

        private float HourRange { get; set; } = 24.0f;

        protected virtual void Update ()
		{
            PerformLightingUpdate();
		}

        private void UpdateLighting (float timePercentage)
		{
            RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercentage);
            RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercentage);

            if (DirectionalLight != null)
			{
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercentage);
                DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercentage * 360.0f) - 90.0f, 170.0f, 0.0f));
			}
		}

        private void PerformLightingUpdate ()
		{
            if (Preset == null)
			{
                return;
			}

            if (Application.isPlaying == true)
			{
                TimeOfDay += Time.deltaTime * TimeScale;
                TimeOfDay %= HourRange;
                UpdateLighting(TimeOfDay / HourRange);
			}
            else
			{
                UpdateLighting(TimeOfDay / HourRange);
            }
        }
    }
}