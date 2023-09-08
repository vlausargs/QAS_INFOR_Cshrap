using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSI.Data.SQL.UDDT
{
    public class DataConverter : IDataConverter
    {
        public decimal ToDecimal(object val)
        {
            return Convert.ToDecimal(val);
        }
        public bool ToBool(object val)
        {
            return Convert.ToBoolean(val);
        }

        public int ToInt(object val)
        {
            return Convert.ToInt32(val);
        }

        public string ToString(object val)
        {
            return Convert.ToString(val);
        }

        public long ToLong(object val)
        {
            return Convert.ToInt64(val);
        }

        public short ToShort(object val)
        {
            return Convert.ToInt16(val);
        }

        public double ToDouble(object val)
        {
            return Convert.ToDouble(val);
        }

        public float ToFloat(object val)
        {
            return Convert.ToSingle(val);
        }

        public byte ToByte(object val)
        {
            return Convert.ToByte(val);
        }

        public Guid ToGuid(object val)
        {
            return Guid.Parse(val.ToString());
        }

        public T ToGeneric<T>(object val)
        {
            if (val == null || val is DBNull)
            {
                if (typeof(T).GetInterfaces().Contains(typeof(IUDDTType)))
                    return CreateUDDTDefault<T>();
                return default(T);
            }

            if (val is T) return (T)val;
            return (T)changeType(val, typeof(T));
        }

        public T ToGeneric<T>(object val, T valueWhenNull) where T : struct
        {
            if (val == null || val is DBNull) return valueWhenNull;
            if (val is T) return (T)val;
            return (T)changeType(val, typeof(T));
        }

        public T ChangeType<T>(object value)
        {
            return (T)changeType(value, typeof(T));
        }

        private object changeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            var fullName = value?.GetType().FullName;
            if (fullName != null && (t.FullName.Contains("CSI.Data.SQL.UDDT")
                                     && fullName.Contains("CSI.Data.SQL.UDDT") == false))
            {
                foreach (var constructorInfo in conversion.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
                {
                    try
                    {
                        return constructorInfo.Invoke(new object[] { value });
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
            if (value is IUDDTType newValue)
                value = newValue.Value;
            return Convert.ChangeType(value, t);
        }

        private T CreateUDDTDefault<T>()
        {
            foreach (var constructorInfo in typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
            {
                try
                {
                    return (T)constructorInfo.Invoke(new object[] { null });
                }
                catch
                {
                    // ignored
                }
            }

            return default(T);
        }
    }
}
