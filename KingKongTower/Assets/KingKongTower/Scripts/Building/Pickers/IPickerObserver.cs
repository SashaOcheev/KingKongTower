namespace Scripts.Building.Pickers
{
    public interface IPickerObserver
    {
        void Register();
        void Unregister();
        void SetPosition(float position);
        void Stop();
    }
}
