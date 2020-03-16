namespace Termigram.State
{
    public abstract class StateBase : IState
    {
        public abstract void SetState(long id, object? state);

        public abstract bool TryGetState(long id, out object? state);

        public abstract bool TryTakeState(long id, out object? state);
    }
}
