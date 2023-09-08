//PROJECT NAME: CSIVendor
//CLASS NAME: ApplyQuickPaymentsPreUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IApplyQuickPaymentsPreUpd
    {
        int ApplyQuickPaymentsPreUpdSp(Guid? pAppmtRowPointer,
                                       ref string Infobar);
    }

    public class ApplyQuickPaymentsPreUpd : IApplyQuickPaymentsPreUpd
    {
        readonly IApplicationDB appDB;

        public ApplyQuickPaymentsPreUpd(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApplyQuickPaymentsPreUpdSp(Guid? pAppmtRowPointer,
                                              ref string Infobar)
        {
            RowPointerType _pAppmtRowPointer = pAppmtRowPointer;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApplyQuickPaymentsPreUpdSp";

                appDB.AddCommandParameter(cmd, "pAppmtRowPointer", _pAppmtRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
