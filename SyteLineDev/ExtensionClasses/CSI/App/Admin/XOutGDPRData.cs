//PROJECT NAME: CSIAdmin
//CLASS NAME: XOutGDPRData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IXOutGDPRData
    {
        int XOutGDPRDataSP(RowPointerType ProcessId);
    }

    public class XOutGDPRData : IXOutGDPRData
    {
        IApplicationDB appDB;

        public XOutGDPRData(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int XOutGDPRDataSP(RowPointerType ProcessId)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XOutGDPRDataSP";

                appDB.AddCommandParameter(cmd, "ProcessId", ProcessId, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

