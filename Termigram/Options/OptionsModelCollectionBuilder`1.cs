using System;
using System.Collections.Generic;
using System.Linq;
using Termigram.Extensions;

namespace Termigram.Options
{
	public class OptionsModelCollectionBuilder<TValue> : OptionsModelValueBuilder<IEnumerable<TValue>?>
    {
		#region Init
		public OptionsModelCollectionBuilder(OptionsModelBuilder builder) : this(builder, default) { }

		public OptionsModelCollectionBuilder(OptionsModelBuilder builder, IEnumerable<TValue>? collection) : base(builder, collection) { }
		#endregion

		#region Functions
		public new OptionsModelCollectionBuilder<TValue> Set(IEnumerable<TValue>? value) => (OptionsModelCollectionBuilder<TValue>)base.Set(value);
		#endregion

		#region Remove
		public virtual OptionsModelCollectionBuilder<TValue> Remove(TValue value)
		{
			if (Value is null)
				return this;

			Value = Value.Where(x => !Equals(x, value));
			return this;
		}

		public virtual OptionsModelCollectionBuilder<TValue> Remove<UValue>() where UValue : TValue => Remove(typeof(UValue));

		public virtual OptionsModelCollectionBuilder<TValue> Remove(Type instanceType)
		{
			if (Value is null)
				return this;

			Value = Value.Where(x => x?.GetType() != instanceType);
			return this;
		}
        #endregion

        #region Prepend
        public virtual OptionsModelCollectionBuilder<TValue> Prepend(TValue value)
		{
			Value ??= Enumerable.Empty<TValue>();

			Value = Value.Prepend(value);
			return this;
		}

		public virtual OptionsModelCollectionBuilder<TValue> Prepend<UValue>() where UValue : TValue => Prepend(Activator.CreateInstance<UValue>());

		public virtual OptionsModelCollectionBuilder<TValue> Prepend(Type instanceType)
		{
			if (!typeof(TValue).IsAssignableFrom(instanceType))
				throw new ArgumentException(nameof(instanceType));

			return Prepend((TValue)Activator.CreateInstance(instanceType));
		}


		public virtual OptionsModelCollectionBuilder<TValue> Prepend(TValue value, Func<TValue, bool> nextElementPredicate)
		{
			Value ??= Enumerable.Empty<TValue>();

			Value = Value.Prepend(value, nextElementPredicate);
			return this;
		}

		public virtual OptionsModelCollectionBuilder<TValue> Prepend(Type instanceType, Func<TValue, bool> nextElementPredicate)
		{
			if (!typeof(TValue).IsAssignableFrom(instanceType))
				throw new ArgumentException(nameof(instanceType));

			return Prepend((TValue)Activator.CreateInstance(instanceType), nextElementPredicate);
		}

		public virtual OptionsModelCollectionBuilder<TValue> Prepend<UValue>(Func<TValue, bool> nextElementPredicate) where UValue : TValue => Prepend(Activator.CreateInstance<UValue>(), nextElementPredicate);


		public virtual OptionsModelCollectionBuilder<TValue> Prepend(TValue value, TValue nextElement) => Prepend(value, x => Equals(x, nextElement));

		public virtual OptionsModelCollectionBuilder<TValue> Prepend(TValue value, Type nextElementType) => Prepend(value, x => x?.GetType() == nextElementType);

		public virtual OptionsModelCollectionBuilder<TValue> Prepend(Type instanceType, Type nextElementType) => Prepend(instanceType, x => x?.GetType() == nextElementType);

		public virtual OptionsModelCollectionBuilder<TValue> Prepend<UValue, UNextValue>() where UValue : TValue where UNextValue : TValue => Prepend<UValue>(x => x?.GetType() == typeof(UNextValue));
        #endregion

        #region Append
        public virtual OptionsModelCollectionBuilder<TValue> Append(TValue value)
		{
			Value ??= Enumerable.Empty<TValue>();

			Value = Value.Append(value);
			return this;
		}

		public virtual OptionsModelCollectionBuilder<TValue> Append<UValue>() where UValue : TValue => Append(Activator.CreateInstance<UValue>());

		public virtual OptionsModelCollectionBuilder<TValue> Append(Type instanceType)
		{
			if (!typeof(TValue).IsAssignableFrom(instanceType))
				throw new ArgumentException(nameof(instanceType));

			return Append((TValue)Activator.CreateInstance(instanceType));
		}


		public virtual OptionsModelCollectionBuilder<TValue> Append(TValue value, Func<TValue, bool> previousElementPredicate)
		{
			Value ??= Enumerable.Empty<TValue>();

			Value = Value.Append(value, previousElementPredicate);
			return this;
		}

		public virtual OptionsModelCollectionBuilder<TValue> Append(Type instanceType, Func<TValue, bool> previousElementPredicate)
		{
			if (!typeof(TValue).IsAssignableFrom(instanceType))
				throw new ArgumentException(nameof(instanceType));

			return Append((TValue)Activator.CreateInstance(instanceType), previousElementPredicate);
		}

		public virtual OptionsModelCollectionBuilder<TValue> Append<UValue>(Func<TValue, bool> previousElementPredicate) where UValue : TValue => Append(Activator.CreateInstance<UValue>(), previousElementPredicate);


		public virtual OptionsModelCollectionBuilder<TValue> Append(TValue value, TValue previousElement) => Append(value, x => Equals(x, previousElement));
		
		public virtual OptionsModelCollectionBuilder<TValue> Append(TValue value, Type previousElementType) => Append(value, x => x?.GetType() == previousElementType);

		public virtual OptionsModelCollectionBuilder<TValue> Append(Type instanceType, Type previousElementType) => Append(instanceType, x => x?.GetType() == previousElementType);

		public virtual OptionsModelCollectionBuilder<TValue> Append<UValue, UPreviousValue>() where UValue : TValue where UPreviousValue : TValue => Append<UValue>(x => x?.GetType() == typeof(UPreviousValue));
		#endregion
	}
}
