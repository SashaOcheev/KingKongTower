namespace Scripts.Building.Pickers
{
    public interface IPickerSubject
    {
        void AddListener(IPickerObserver observer);
        void SetPositionToListeners(float position);
        void RemoveListener(IPickerObserver observer);
        void Stop();
    }
}
