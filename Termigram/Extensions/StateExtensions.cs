using System.Diagnostics.CodeAnalysis;
using Telegram.Bot.Types;
using Termigram.State;

namespace Termigram.Extensions
{
    public static class StateExtensions
    {
        public static void SetState(this IState stateStorage, User user, object? state) => stateStorage.SetState(user.Id, state);

        public static bool TryGetState(this IState stateStorage, User user, out object? state) => stateStorage.TryGetState(user.Id, out state);

        public static bool TryTakeState(this IState stateStorage, User user, out object? state) => stateStorage.TryTakeState(user.Id, out state);

        public static bool TryGetState<T>(this IState stateStorage, User user, [MaybeNull]out T state) => TryGetState(stateStorage, user.Id, out state);

        public static bool TryGetState<T>(this IState stateStorage, long id, [MaybeNull]out T state)
        {
            if (stateStorage.TryGetState(id, out object? objState) && objState is T typedState)
            {
                state = typedState;
                return true;
            }
            else
            {
                state = default!;
                return false;
            }          
        }

        public static bool TryTakeState<T>(this IState stateStorage, User user, [MaybeNull]out T state) => TryTakeState(stateStorage, user.Id, out state);

        public static bool TryTakeState<T>(this IState stateStorage, long id, [MaybeNull]out T state)
        {
            if (stateStorage.TryTakeState(id, out object? objState) && objState is T typedState)
            {
                state = typedState;
                return true;
            }
            else
            {
                state = default!;
                return false;
            }
        }
    }
}
