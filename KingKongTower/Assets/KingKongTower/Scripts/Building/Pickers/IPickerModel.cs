namespace Scripts.Building.Pickers
{
    public interface IPickerModel
    {
        float Position { get; }
        void IncrementSpeed();
        bool InBoundary { get; }
        
        bool IsAllowable { set; get; }
    }
}