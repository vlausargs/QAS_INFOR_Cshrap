//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtPostNeeded.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtPostNeeded
    {
        int AppmtPostNeededSp(Guid? PSessionID,
                              ref byte? RPostNeeded,
                              ref string Infobar);
    }

    public class AppmtPostNeeded : IAppmtPostNeeded
    {
        readonly IApplicationDB appDB;

        public AppmtPostNeeded(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtPostNeededSp(Guid? PSessionID,
                                     ref byte? RPostNeeded,
                                     ref string Infobar)
        {
            RowPointerType _PSessionID = PSessionID;
            FlagNyType _RPostNeeded = RPostNeeded;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtPostNeededSp";

                appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RPostNeeded", _RPostNeeded, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                RPostNeeded = _RPostNeeded;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
