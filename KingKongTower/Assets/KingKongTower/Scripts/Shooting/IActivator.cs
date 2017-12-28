namespace Scripts.Shooting
{
    public interface IActivator
    {
        void AddLitener(IActivated activated);
        void ActivateListeners();
        void Stop();

        bool IsEnd { get; set; }
        bool IsWin { get; set; }

        void MakeDamage();
    }
}