using System;

namespace Termigram.Commands
{
    [Flags]
    public enum Bindings
    {
        None            = 0,

        Public          = 1 << 0,
        NonPublic       = 1 << 1,
        Instance        = 1 << 2,
        Static          = 1 << 3,
        MarkedAsCommand = 1 << 4,
        Inherited       = 1 << 5,
        
        Any = Public | NonPublic | Instance | Static,
        AnyStatic = Public | NonPublic | Static,
        AnyInstance = Public | NonPublic | Instance,
        Default = Public | NonPublic | Instance | Static | MarkedAsCommand
    }
}
