
namespace Scripts.Building.SetUpBlockPhases
{
    public interface IPhase
    {
        void Start();
        bool IsEnd { get; }
    }
}