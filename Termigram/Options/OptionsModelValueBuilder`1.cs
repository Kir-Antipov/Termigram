using System;
using System.Diagnostics.CodeAnalysis;

namespace Termigram.Options
{
    public class OptionsModelValueBuilder<TValue>
    {
        #region Var
        [MaybeNull, AllowNull]
        protected TValue Value;

        public OptionsModelBuilder OptionsModelBuilder { get; }
        #endregion

        #region Init
        public OptionsModelValueBuilder(OptionsModelBuilder builder) : this(builder, default!) { }

        public OptionsModelValueBuilder(OptionsModelBuilder builder, [MaybeNull, AllowNull] TValue value)
        {
            OptionsModelBuilder = builder;
            Value = value;
        }
        #endregion

        #region Functions
        [return: MaybeNull]
        public TValue Build() => Value;

        public virtual OptionsModelValueBuilder<TValue> Set([MaybeNull, AllowNull] TValue value)
        {
            Value = value;
            return this;
        }

        public virtual OptionsModelValueBuilder<TValue> Set<UValue>() where UValue : TValue => Set(Activator.CreateInstance<UValue>());

        public virtual OptionsModelValueBuilder<TValue> Set(Type instanceType)
        {
            if (!typeof(TValue).IsAssignableFrom(instanceType))
                throw new ArgumentException(nameof(instanceType));

            return Set((TValue)Activator.CreateInstance(instanceType));
        }
        #endregion
    }
}
