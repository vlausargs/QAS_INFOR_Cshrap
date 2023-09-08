//PROJECT NAME: CSIEmployee
//CLASS NAME: PMTAttachFromTemp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPMTAttachFromTemp
    {
        int PMTAttachFromTempSp(RowPointerType RowPointer,
                                NameType PmpName);
    }

    public class PMTAttachFromTemp : IPMTAttachFromTemp
    {
        readonly IApplicationDB appDB;

        public PMTAttachFromTemp(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PMTAttachFromTempSp(RowPointerType RowPointer,
                                       NameType PmpName)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PMTAttachFromTempSp";

                appDB.AddCommandParameter(cmd, "RowPointer", RowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PmpName", PmpName, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
