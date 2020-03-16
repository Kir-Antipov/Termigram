namespace Termigram.State
{
    public interface IState
    {
        void SetState(long id, object? state);

        bool TryGetState(long id, out object? state);

        bool TryTakeState(long id, out object? state);
    }
}
