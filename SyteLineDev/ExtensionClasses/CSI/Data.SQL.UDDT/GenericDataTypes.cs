using System;
using System.Data;
using System.Data.SqlTypes;

namespace CSI.Data.SQL.UDDT
{
    public class BooleanType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToBool(value); }
        }
        public virtual int Length { get => 1; }
        public virtual byte Precision { get => 0; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Boolean; }

        public bool? Value
        {
            get
            {
                if (this._value == null || this._value == System.DBNull.Value) return null;
                return (bool?)this._value;
            }
            protected set { this._value = value; }
        }
        protected BooleanType(bool? value)
        { this.Value = value; }
        public static implicit operator BooleanType(bool? value) { return new BooleanType(value); }
        public static implicit operator BooleanType(DBNull value) { return new BooleanType(null); }
        public static implicit operator bool? (BooleanType inputparameter) { return inputparameter.Value; }
        public static implicit operator bool(BooleanType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public bool GetValue(bool ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }

    }
    public class ByteType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToByte(value); }
        }
        public virtual int Length { get => 1; }
        public virtual byte Precision { get => 3; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Byte; }

        public byte? Value
        {
            get
            {
                if (this._value == null || this._value == System.DBNull.Value) return null;
                return (byte?)this._value;
            }
            private set { this._value = value; }
        }
        protected ByteType(byte? value) 
        { this.Value = value; }

        protected ByteType(int? value) 
        { this.Value = (byte?)(value); }
        public static implicit operator ByteType(byte? value) { return new ByteType(value); }
        public static implicit operator ByteType(int? value) { return new ByteType(value); }
        public static implicit operator ByteType(DBNull value) { return new ByteType(null); }
        public static implicit operator byte? (ByteType inputparameter) { return inputparameter.Value; }
        public static implicit operator byte(ByteType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public static implicit operator int? (ByteType inputparameter) { return inputparameter.Value; }
        public static implicit operator int(ByteType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public byte GetValue(byte ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }

    }
    public class BinaryType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = (byte[])(value); }
        }
        public virtual int Length { get => -1; }
        public virtual byte Precision { get => 0; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Binary; }

        public Byte[] Value
        {
            get
            {
                if (this._value == null || this._value == System.DBNull.Value) return null;
                return (Byte[])this._value;
            }
            private set { this._value = value; }
        }
        protected BinaryType(Byte[] value) 
        { this.Value = value; }
        public static implicit operator BinaryType(Byte[] value) { return new BinaryType(value); }
        public static implicit operator BinaryType(DBNull value) { return new BinaryType(null); }
        public static implicit operator Byte[] (BinaryType inputparameter) { return inputparameter.Value; }
        public bool IsNull { get { return Value == null; } }
    }
    public class DateTimeType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value { get => this.Value; set => this._value = value; }
        public virtual int Length { get => 8; }
        public virtual byte Precision { get => 23; }
        public virtual byte Scale { get => 3; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.DateTime; }

        public DateTime? Value
        {
            get
            {
                if (this._value == null || this._value == System.DBNull.Value) return null;
                return (DateTime?)this._value;
            }
            private set { this._value = value; }
        }
        protected DateTimeType(DateTime? value) 
        { this.Value = value; }
        public static implicit operator DateTimeType(DateTime? value) { return new DateTimeType(value); }
        public static implicit operator DateTimeType(DBNull value) { return new DateTimeType(null); }
        public static implicit operator DateTime? (DateTimeType inputparameter) { return inputparameter.Value; }
        public static implicit operator DateTime(DateTimeType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public static DateTimeType operator +(DateTimeType dateTime1, DateTimeType dateTime2)
        {
            if (dateTime1 == null || dateTime2 == null ||
                dateTime1.Value == null || dateTime2.Value == null)
                return null;

            DateTime zeroPointDateTime = new DateTime(1900, 1, 1);
            TimeSpan firstDiff = (DateTime)dateTime1.Value - zeroPointDateTime;
            TimeSpan secondDiff = (DateTime)dateTime2.Value - zeroPointDateTime;

            DateTime newDateTime = zeroPointDateTime + firstDiff + secondDiff;
            DateTimeType newDateTimeType = new DateTimeType(newDateTime);
            return newDateTimeType;
        }
        public static DateTimeType operator -(DateTimeType dateTime1, DateTimeType dateTime2)
        {
            if (dateTime1 == null || dateTime2 == null ||
                dateTime1.Value == null || dateTime2.Value == null)
                return null;

            DateTime zeroPointDateTime = new DateTime(1900, 1, 1);
            TimeSpan firstDiff = (DateTime)dateTime1.Value - zeroPointDateTime;
            TimeSpan secondDiff = (DateTime)dateTime2.Value - zeroPointDateTime;

            DateTime newDateTime = zeroPointDateTime + firstDiff - secondDiff;
            DateTimeType newDateTimeType = new DateTimeType(newDateTime);
            return newDateTimeType;
        }
        public DateTime GetValue(DateTime ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }

    }
    public class DecimalType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToDecimal(value); }
        }

        public virtual int Length { get => 17; }
        public virtual byte Precision { get => 38; }
        public virtual byte Scale { get => 16; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Decimal; }
        public decimal? Value
        {
            get
            {
                if (this._value == null || this._value == System.DBNull.Value) return null;
                decimal _newValue = decimal.Parse(((decimal)_value).ToString($"f{Scale}"));
                if(Math.Floor(Math.Abs(_newValue)).ToString().Length <= Precision- Scale)
                    return _newValue;
                else
                    throw new Exception("Arithmetic overflow error converting numeric to data type numeric.");
            }
            private set { this._value = value; }
        }
        protected DecimalType(decimal? value) 
        { this.Value = value; }
        public static implicit operator DecimalType(decimal? value) { return new DecimalType(value); }
        public static implicit operator DecimalType(DBNull value) { return new DecimalType(null); }
        public static implicit operator decimal? (DecimalType inputparameter) { return inputparameter.Value; }
        public static implicit operator decimal(DecimalType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public decimal GetValue(decimal ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }
    }
    public class FloatType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToDouble(value); }
        }
        public virtual int Length { get => 8; }
        public virtual byte Precision { get => 53; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Double; }
        public double? Value
        {
            get
            {
                if (this._value == null || this._value == System.DBNull.Value) return null;
                return (double?)this._value;
            }
            private set { this._value = value; }
        }
        protected FloatType(double? value) 
        { this.Value = value; }
        protected FloatType(decimal? value) 
        { this.Value = (double?)(value); }
        public static implicit operator FloatType(double? value) { return new FloatType(value); }
        public static implicit operator FloatType(decimal? value) { return new FloatType(value); }
        public static implicit operator FloatType(DBNull value) { return new FloatType((double?) null); }
        public static implicit operator double? (FloatType inputparameter) { return inputparameter.Value; }
        public static implicit operator double(FloatType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public static implicit operator decimal? (FloatType inputparameter) { return (decimal?)inputparameter.Value; }        
        public static implicit operator decimal (FloatType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
             return Convert.ToDecimal(inputparameter.Value); 
        }
        public double GetValue(double ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }
    }
    public class GuidType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToGuid(value); }
        }
        public virtual int Length { get => 16; }
        public virtual byte Precision { get => 0; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Guid; }
        public Guid? Value
        {
            get
            {
                if (this._value == null || this._value == System.DBNull.Value) return null;
                return (Guid?)this._value;
            }
            private set { this._value = value; }
        }
        protected GuidType(Guid? value) 
        {this.Value = value; }
        protected GuidType(string value) 
        {this.Value = value== null? (Guid?)null : new Guid(value); }
        public static implicit operator GuidType(Guid? value) { return new GuidType(value); }
        public static implicit operator GuidType(DBNull value) { return new GuidType((Guid?)null); }
        public static implicit operator Guid? (GuidType inputparameter) { return inputparameter.Value; }
        public static implicit operator Guid(GuidType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public static implicit operator string(GuidType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                return null;
            return Convert.ToString(inputparameter.Value.GetValueOrDefault());
        }
        public Guid GetValue(Guid ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }

    }
    public class IntType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToInt(value); }
        }
        public virtual int Length { get=>4; }
        public virtual byte Precision { get=>10; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Int32; }
        public int? Value
        {
            get
            {
                if (_value == null || _value == System.DBNull.Value) return null;
                return (int?)_value;
            }
            private set { _value = value; }
        }
        protected IntType(int? value) 
        { this.Value = value; }
        protected IntType(long? value) 
        { this.Value = (int?)(value); }
        public static implicit operator IntType(int? value) { return new IntType(value); }
        public static implicit operator IntType(DBNull value) { return new IntType(null); }
        public static implicit operator int? (IntType inputparameter) { return inputparameter.Value; }
        public static implicit operator int(IntType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public static implicit operator IntType(long? value) { return new IntType(value); }
        public static implicit operator long? (IntType inputparameter) { return inputparameter.Value; }
        public static implicit operator long(IntType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public int GetValue(int ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }

    }
    public class LongType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToLong(value); }
        }
        public virtual int Length { get => 8; }
        public virtual byte Precision { get => 19; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Int64; }
        public long? Value
        {
            get
            {
                if (_value == null || _value == System.DBNull.Value) return null;
                return (long?)_value;
            }
            private set { _value = value; }
        }
        protected LongType(long? value) 
        { this.Value = value; }
        public static implicit operator LongType(long? value) { return new LongType(value); }
        public static implicit operator LongType(DBNull value) { return new LongType(null); }
        public static implicit operator long? (LongType inputparameter) { return inputparameter.Value; }
        public static implicit operator long(LongType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public long GetValue(long ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }

    }
    public class ShortType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToShort(value); }
        }
        public virtual int Length { get => 2; }
        public virtual byte Precision { get => 5; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get=> DbType.Int16; }
        public short? Value
        {
            get
            {
                if (_value == null || _value == System.DBNull.Value) return null;
                return (short?)_value;
            }
            private set { _value = value; }
        }
        protected ShortType(short? value) 
        { this.Value = value; }
        protected ShortType(int? value) 
        { this.Value = (short?) value; }
        public static implicit operator ShortType(short? value) { return new ShortType(value); }
        public static implicit operator ShortType(DBNull value) { return new ShortType(null); }
        public static implicit operator short? (ShortType inputparameter) { return inputparameter.Value; }
        public static implicit operator short(ShortType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public static implicit operator ShortType(int? value) { return new ShortType(value); }
        public static implicit operator int? (ShortType inputparameter) { return inputparameter.Value; }
        public static implicit operator int(ShortType inputparameter)
        {
            if (inputparameter == null || inputparameter.Value.HasValue == false)
                throw new UDDTImplicitConversionException(inputparameter.GetType().Name, inputparameter.Value.GetValueOrDefault().GetType().Name);
            return inputparameter.Value.GetValueOrDefault();
        }
        public short GetValue(short ifNullValue)
        {
            return (IsNull) ? Value.GetValueOrDefault() : ifNullValue;
        }
        public bool IsNull { get { return !Value.HasValue; } }

    }
    public class StringType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value
        {
            get => this.Value;
            set { if (value == null || value == DBNull.Value) _value = value; else this._value = new DataConverter().ToString(value); }
        }
        public virtual int Length { get => -1 ;}
        public virtual byte Precision { get => 0;  }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false;  }
        public DbType DbType { get => DbType.String; }
        public string Value
        {
            get
            {
                if (_value == null || _value == System.DBNull.Value) return null;
                string _newValue = (string)this._value;
                if (_newValue.Length > Length && Length > 0)
                    return _newValue.Substring(0, Length / 2);
                else
                    return (string)_value;
            }
            private set { _value = value; }
        }
        protected StringType(string value) 
        { this.Value = value; }
        public static implicit operator StringType(string value) { return new StringType(value); }
        public static implicit operator StringType(DBNull value) { return new StringType(null); }
        public static implicit operator string(StringType inputparameter) { return inputparameter.Value; }
        public bool IsNull { get { return Value == null; } }
    }
    public class SqlXmlType : IUDDTType
    {
        private object _value;
        object IUDDTType.Value { get => this.Value; set => this._value = value; }
        public virtual int Length { get => -1; }
        public virtual byte Precision { get => 0; }
        public virtual byte Scale { get => 0; }
        public virtual bool Nullable { get => false; }
        public DbType DbType { get => DbType.Xml; }
        public SqlXml Value
        {
            get
            {
                if (_value == null || _value == System.DBNull.Value) return null;
                return (SqlXml)_value;
            }
            private set { _value = value; }
        }
        protected SqlXmlType(SqlXml value) 
        {this.Value = value; }
        public static implicit operator SqlXmlType(SqlXml value) { return new SqlXmlType(value); }
        public static implicit operator SqlXmlType(DBNull value) { return new SqlXmlType(null); }
        public static implicit operator SqlXml(SqlXmlType inputparameter) { return inputparameter.Value; }
        public bool IsNull { get { return Value == null; } }
    }
}
