using System.Collections.Generic;
using Termigram.CommandInfos;
using Termigram.Commands;
using Termigram.Converters;
using Termigram.DefaultValueProviders;
using Termigram.SpecialValueProviders;

namespace Termigram.CommandLinkers
{
    public interface ICommandLinker
    {
        /// <summary>
        /// Returns compatibility of the received <see cref="ICommand"/> and the <see cref="ICommandInfo"/> implemented by the bot.
        /// </summary>
        /// <returns>
        /// Compatibility of the received <see cref="ICommand"/> and the <see cref="ICommandInfo"/> implemented by the bot.
        /// <para/>
        /// 0.0 - Completely incompatible.
        /// <para/>
        /// 1.0 - Fully compatible.
        /// </returns>
        double GetCompatibility(ICommand command, ICommandInfo commandInfo, IEnumerable<IConverter>? converters = null, IEnumerable<IDefaultValueProvider>? defaultValueProviders = null, IEnumerable<ISpecialValueProvider>? specialValueProviders = null);
    }
}
