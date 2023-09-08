//PROJECT NAME: Production
//CLASS NAME: IPmfPnMatIssued.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
    public interface IPmfPnMatIssued
    {
        (int? ReturnCode,
        string warning) PmfPnMatIssuedSp(
            Guid? job_RowPointer,
            int? op_complete,
            string warning);
    }
}

