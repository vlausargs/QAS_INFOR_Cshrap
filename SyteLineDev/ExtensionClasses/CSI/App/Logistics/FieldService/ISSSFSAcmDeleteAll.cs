//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAcmDeleteAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSAcmDeleteAll
    {
        (int? ReturnCode,
        string AcmNum,
        string Infobar) SSSFSAcmDeleteAllSp(
            string AcmNum,
            string Infobar);
    }
}