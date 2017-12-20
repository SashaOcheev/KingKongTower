namespace Scripts
{
    public interface IGameStage
    {
        void StartStage();
        void StopStage();

        bool IsStart { get; }
        bool IsStop { get; }
    }
}
