namespace Hydroponical.Logic.Buildings
{
    public interface IBlockModuleApplicable
    {
        void SwitchWall (BlockModuleController.WallSide side, bool isOpen);
    }
}