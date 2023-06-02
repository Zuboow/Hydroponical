using System;
using UnityEngine;

namespace Hydroponical.Logic.TimeManagement
{
    public class TimeController : SingletonMonoBehaviour<TimeController>
    {
        public Action OnDayPass { get; set; } = delegate { };

        [field: SerializeField, Range(0, 24)]
        public float TimeOfDay { get; private set; }
        [field: SerializeField]
        public float TimeScale { get; private set; } = 1.0f;

        private float HourRange { get; set; } = 24.0f;

        public float GetDayPercentage ()
		{
            return TimeOfDay / HourRange;
		}

        protected virtual void Update ()
        {
            PerformTimeOfDayUpdate();
        }

        private void PerformTimeOfDayUpdate ()
        {
            if (Application.isPlaying == true)
            {
                TimeOfDay += Time.deltaTime * TimeScale;

                if (TimeOfDay >= HourRange)
				{
                    NotifyOnDayPass();
				}

                TimeOfDay %= HourRange;
            }
        }

        private void NotifyOnDayPass ()
		{
            OnDayPass.Invoke();
		}
    }
}