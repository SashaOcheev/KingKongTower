namespace Scripts.Building
{
    public interface IPickerState
    {
        float AbsMaxAllowableDeviation { get; }
        /* Отрицательое число - мы слева от центра,
        * Положительное - справа
        */
        float PositionPercent { get; }
        void IncrementSpeed();
        bool InBoundary { get; }
    }
}