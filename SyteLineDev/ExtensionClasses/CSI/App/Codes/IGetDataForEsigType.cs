//PROJECT NAME: Codes
//CLASS NAME: IGetDataForEsigType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
    public interface IGetDataForEsigType
    {
            (int? ReturnCode,
            string Description,
        int? Enabled) GetDataForEsigTypeSp(
            string EsigType,
            string Description,
            int? Enabled);
    }
}

