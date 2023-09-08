//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXPackSlipQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXPackSlipQtyValid
    {
        int SSSRMXPackSlipQtyValidSp(decimal? QtyRequired,
                                     decimal? QtyToPack,
                                     string TPckCall,
                                     ref string Warning,
                                     ref string Infobar);
    }

    public class SSSRMXPackSlipQtyValid : ISSSRMXPackSlipQtyValid
    {
        readonly IApplicationDB appDB;

        public SSSRMXPackSlipQtyValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXPackSlipQtyValidSp(decimal? QtyRequired,
                                            decimal? QtyToPack,
                                            string TPckCall,
                                            ref string Warning,
                                            ref string Infobar)
        {
            QtyUnitType _QtyRequired = QtyRequired;
            QtyUnitType _QtyToPack = QtyToPack;
            StringType _TPckCall = TPckCall;
            InfobarType _Warning = Warning;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXPackSlipQtyValidSp";

                appDB.AddCommandParameter(cmd, "QtyRequired", _QtyRequired, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyToPack", _QtyToPack, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TPckCall", _TPckCall, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Warning", _Warning, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Warning = _Warning;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
