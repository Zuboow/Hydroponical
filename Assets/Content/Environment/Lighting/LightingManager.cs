using Hydroponical.Logic.TimeManagement;
using Hydroponical.Settings;
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

        //For Editor use only
        [field: SerializeField]
        private TimeSettingsScriptableObject TimeSettings { get; set; }
        //

        protected virtual void Update ()
		{
            if (Application.isPlaying == true)
			{
                PerformLightingUpdate(TimeController.Instance.GetDayPercentage());
			}
            else
			{
                EditorLightingUpdate();
			}
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

        // For Editor use only
        private void EditorLightingUpdate ()
		{
            if (Preset == null)
            {
                return;
            }

            UpdateLighting(TimeSettings.TimeOfDay / TimeSettings.HourRange);
        }
    }
}