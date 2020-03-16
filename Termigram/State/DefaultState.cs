using System.Collections.Concurrent;

namespace Termigram.State
{
    public class DefaultState : StateBase
    {
        #region Var
        private readonly ConcurrentDictionary<long, object?> Storage = new ConcurrentDictionary<long, object?>();
        #endregion

        #region Functions
        public override void SetState(long id, object? state) => Storage.AddOrUpdate(id, state, (a, b) => state);

        public override bool TryGetState(long id, out object? state) => Storage.TryGetValue(id, out state);

        public override bool TryTakeState(long id, out object? state) => Storage.TryRemove(id, out state);
        #endregion
    }
}
