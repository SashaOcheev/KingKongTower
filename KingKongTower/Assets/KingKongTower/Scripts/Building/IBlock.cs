using Scripts.Building.Pickers;

namespace Scripts.Building
{
    public interface IBlock : IPickerObserver
    {
        void Put();
    }
}
