//PROJECT NAME: Data
//CLASS NAME: IRefSetDescSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
    public interface IRefSetDesc
    {
        string RefSetDescSp(
            string JobOrdType,
            string JobOrdTypeDesc,
            string JobOrdNum,
            int? JobOrdLine,
            int? JobOrdRelease);
    }
}

