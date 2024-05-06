namespace GameStateSystem
{
    public interface IStateMachine
    {
        bool ChangeState<T>();
    }
}