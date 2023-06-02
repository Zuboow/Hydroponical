using Hydroponical.Logic.TimeManagement;
using System.Collections.Generic;
using UnityEngine;

namespace Hydroponical.Logic.Interactables.Plants
{
    public class PlantGrowingController : MonoBehaviour, IInteractable
    {
        [field: SerializeField]
        private List<Transform> GrowingStages { get; set; }

        [field: SerializeField]
        private int HarvestStageIndex { get; set; }
        [field: SerializeField]
        private int AfterHarvestStageIndex { get; set; }
        [field: SerializeField]
        private int CurrentGrowingStageIndex { get; set; } = 0;
        [field: SerializeField]
        private bool IsRemovedAfterHarvest { get; set; } = false;

        private Transform CurrentStage { get; set; }

        public bool IsCurrentlyInteractable ()
        {
            return HarvestStageIndex == CurrentGrowingStageIndex;
        }

        public void Interact ()
        {
            HarvestPlant();
        }

        protected virtual void Start ()
		{
            AttachToEvents();
            SpawnPlant(CurrentGrowingStageIndex);
		}

        protected virtual void OnDestroy ()
        {
            DetachFromEvents();
        }

        private void AttachToEvents ()
		{
            TimeController.Instance.OnDayPass += ReactToDayChange;
		}

        private void DetachFromEvents ()
		{
            TimeController.Instance.OnDayPass -= ReactToDayChange;
        }

        private void ReactToDayChange ()
		{
            if (CurrentGrowingStageIndex < GrowingStages.Count - 1)
			{
                CurrentGrowingStageIndex++;
                ReplaceGrowingStage(CurrentGrowingStageIndex);
			}
		}

        private void ReplaceGrowingStage (int stageIndex)
		{
            Destroy(CurrentStage.gameObject);
            SpawnPlant(stageIndex);
		}

        private void SpawnPlant (int stageIndex)
		{
            CurrentStage = Instantiate(GrowingStages[stageIndex], transform.position, transform.rotation, transform);
        }

        private void HarvestPlant ()
		{
            if (IsRemovedAfterHarvest == true)
			{
                RemovePlant();
			}
            else
			{
                ReplaceGrowingStage(AfterHarvestStageIndex);
			}
		}

        private void RemovePlant ()
		{

		}
    }
}