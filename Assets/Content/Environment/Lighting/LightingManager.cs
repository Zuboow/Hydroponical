using Hydroponical.Logic.TimeManagement;
using UnityEngine;

namespace Hydroponical.Logic.Lighting
{
    public class LightingManager : MonoBehaviour
    {
        [field: SerializeField]
        private Light DirectionalLight { get; set; }
        [field: SerializeField]
        private LightingPreset Preset { get; set; }

        protected virtual void Update ()
		{
            PerformLightingUpdate(TimeController.Instance.GetDayPercentage());
		}

        private void UpdateLighting (float dayPercentage)
		{
            RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(dayPercentage);
            RenderSettings.fogColor = Preset.FogColor.Evaluate(dayPercentage);

            if (DirectionalLight != null)
			{
                DirectionalLight.color = Preset.DirectionalColor.Evaluate(dayPercentage);
                DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((dayPercentage * 360.0f) - 90.0f, 170.0f, 0.0f));
			}
		}

        private void PerformLightingUpdate (float dayPercentage)
		{
            if (Preset == null)
			{
                return;
			}

            UpdateLighting(dayPercentage);
        }
    }
}