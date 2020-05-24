using System;

namespace Termigram.Options
{
    public class OptionsModelFactoryBuilder<TValue> : OptionsModelValueBuilder<Func<TValue>?>
    {
        #region Init
        public OptionsModelFactoryBuilder(OptionsModelBuilder builder) : this(builder, default) { }

        public OptionsModelFactoryBuilder(OptionsModelBuilder builder, Func<TValue>? factory) : base(builder, factory) { }
        #endregion

        #region Functions
        public new OptionsModelFactoryBuilder<TValue> Set(Func<TValue>? value) => (OptionsModelFactoryBuilder<TValue>)base.Set(value);

        public virtual OptionsModelFactoryBuilder<TValue> Set(TValue value)
        {
            _ = value ?? throw new ArgumentNullException(nameof(value));

            Value = () => value;
            return this;
        }

        public new virtual OptionsModelFactoryBuilder<TValue> Set<UValue>() where UValue : TValue => Set(() => Activator.CreateInstance<UValue>());

        public new virtual OptionsModelFactoryBuilder<TValue> Set(Type instanceType)
        {
            if (!typeof(TValue).IsAssignableFrom(instanceType))
                throw new ArgumentException(nameof(instanceType));

            return Set(() => (TValue)Activator.CreateInstance(instanceType));
        }
        #endregion
    }
}
