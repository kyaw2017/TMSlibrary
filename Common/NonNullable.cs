using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSLibrary.Common
{
    public struct NonNullable<T> where T : class
    {
        private readonly T value;
        public NonNullable(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            this.value = value;
        }

        public T Value
        {
            get
            {
                if (value == null)
                {
                    throw new NullReferenceException();
                }
                return value;
            }
        }

        public static implicit operator NonNullable<T>(T value)
        {
            return new NonNullable<T>(value);
        }

        public static implicit operator T(NonNullable<T> wrapper)
        {
            return wrapper.Value;
        }
    }
}
