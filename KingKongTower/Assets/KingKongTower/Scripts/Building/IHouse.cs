namespace Scripts.Building
{
    public interface IHouse
    {
        void CreateNextBlock();
        bool CanCreateNextBlock { get; }
        int Height { get; set; }
    }
}