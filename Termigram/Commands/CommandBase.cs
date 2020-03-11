using Telegram.Bot.Types;

namespace Termigram.Commands
{
    public abstract class CommandBase : ICommand
    {
        #region Var
        public string Name { get; }

        public Update Update { get; }
        #endregion

        #region Init
        public CommandBase(string name, Update update) => (Name, Update) = (name, update);
        #endregion

        #region Functions
        public override string ToString() => Name;
        public override int GetHashCode() => Update.Id;
        public override bool Equals(object? obj) => obj is CommandBase cmd && cmd.Update.Id == Update.Id && cmd.Name == Name;
        #endregion
    }
}
