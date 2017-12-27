namespace Scripts.Shooting
{
    public interface IActivated
    {
        void Activate(Metadata metadata);
        void Register(IActivator activator);
        void Stop();

        void MakeDamage();
    }
}