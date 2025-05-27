namespace Game.Plant
{
    public interface ICanUpgrade
    {
        int Grade { get; }
        void OnGrowUp(int grade);
    }
}