namespace Scripts.Building.Pickers
{
    public interface IPickerModel
    {
        float AbsMaxAllowableDeviation { get; }
        /* Отрицательое число - мы слева от центра,
        * Положительное - справа
        * от -100 до 100
        */
        float Position { get; }
        void IncrementSpeed();
        bool InBoundary { get; }
    }
}