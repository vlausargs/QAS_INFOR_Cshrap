//PROJECT NAME: CSIVendor
//CLASS NAME: APWirePosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AP
{
    public interface IAPWirePosting
    {
        int APWirePostingSp(RowPointer PSessionID,
                            RowPointer PAppmtRowPointer,
                            ref InfobarType Infobar);
    }

    public class APWirePosting : IAPWirePosting
    {
        readonly IApplicationDB appDB;

        public APWirePosting(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int APWirePostingSp(RowPointer PSessionID,
                                   RowPointer PAppmtRowPointer,
                                   ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "APWirePostingSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAppmtRowPointer", PAppmtRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
