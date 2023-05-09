using UnityEngine;

namespace Hydroponical.Logic.Buildings
{
    public class BlockModuleController : MonoBehaviour, IBlockModuleApplicable
    {
        [field: SerializeField]
        private Transform BlankEastWall { get; set; }
        [field: SerializeField]
        private Transform BlankWestWall { get; set; }
        [field: SerializeField]
        private Transform BlankNorthWall { get; set; }
        [field: SerializeField]
        private Transform BlankSouthWall { get; set; }
        [field: SerializeField]
        private Transform EntranceEastWall { get; set; }
        [field: SerializeField]
        private Transform EntranceWestWall { get; set; }
        [field: SerializeField]
        private Transform EntranceNorthWall { get; set; }
        [field: SerializeField]
        private Transform EntranceSouthWall { get; set; }

        [field: SerializeField]
        private bool IsEastWallOpen { get; set; }
        [field: SerializeField]
        private bool IsWestWallOpen { get; set; }
        [field: SerializeField]
        private bool IsNorthWallOpen { get; set; }
        [field: SerializeField]
        private bool IsSouthWallOpen { get; set; }

        public void SwitchWall(WallSide side, bool isOpen)
		{
            switch (side)
            {
                case WallSide.East:
                    BlankEastWall.gameObject.SetActive(!isOpen);
                    EntranceEastWall.gameObject.SetActive(isOpen);
                    break;
                case WallSide.West:
                    BlankWestWall.gameObject.SetActive(!isOpen);
                    EntranceWestWall.gameObject.SetActive(isOpen);
                    break;
                case WallSide.North:
                    BlankNorthWall.gameObject.SetActive(!isOpen);
                    EntranceNorthWall.gameObject.SetActive(isOpen);
                    break;
                case WallSide.South:
                    BlankSouthWall.gameObject.SetActive(!isOpen);
                    EntranceSouthWall.gameObject.SetActive(isOpen);
                    break;
            }
		}

        protected virtual void Start ()
		{
            UpdateWallsOnStart();
		}

        private void UpdateWallsOnStart ()
		{
            SwitchWall(WallSide.East, IsEastWallOpen);
            SwitchWall(WallSide.West, IsWestWallOpen);
            SwitchWall(WallSide.North, IsNorthWallOpen);
            SwitchWall(WallSide.South, IsSouthWallOpen);
        }

        public enum WallSide
		{
            East,
            West,
            North,
            South
		}
    }
}