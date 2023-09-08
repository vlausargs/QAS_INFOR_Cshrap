using System;
using System.Data;

namespace CSI.Data.SQL.UDDT
{
    public interface IUDDTType
    {
        object Value { get; set; }
        int Length { get; }
        byte Precision { get; }
        byte Scale { get;  }
        bool Nullable { get; }
        DbType DbType { get; }
        /*getValues.....*/
    }

}
