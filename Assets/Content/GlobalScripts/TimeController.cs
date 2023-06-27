using Hydroponical.Settings;
using System;
using UnityEngine;

namespace Hydroponical.Logic.TimeManagement
{
    public class TimeController : SingletonMonoBehaviour<TimeController>
    {
        public Action OnDayPass { get; set; } = delegate { };

        [field: SerializeField]
        private TimeSettingsScriptableObject TimeSettings { get; set; }
        [field: SerializeField]
        private float InitialTime { get; set; } = 6.0f;

        public float GetDayPercentage ()
		{
            return TimeSettings.TimeOfDay / TimeSettings.HourRange;
		}

        protected virtual void Start ()
        {
            InitializeTime(InitialTime);
        }

        protected virtual void Update ()
        {
            PerformTimeOfDayUpdate();
        }

        private void InitializeTime (float initialTime)
		{
            TimeSettings.TimeOfDay = initialTime;
		}

        private void PerformTimeOfDayUpdate ()
        {
            if (Application.isPlaying == true)
            {
                TimeSettings.TimeOfDay += Time.deltaTime * TimeSettings.TimeScale;

                if (TimeSettings.TimeOfDay >= TimeSettings.HourRange)
				{
                    NotifyOnDayPass();
				}

                TimeSettings.TimeOfDay %= TimeSettings.HourRange;
            }
        }

        private void NotifyOnDayPass ()
		{
            OnDayPass.Invoke();
		}
    }
}