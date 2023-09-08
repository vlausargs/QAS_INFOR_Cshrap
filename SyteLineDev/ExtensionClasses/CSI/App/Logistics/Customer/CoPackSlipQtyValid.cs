//PROJECT NAME: CSICustomer
//CLASS NAME: CoPackSlipQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICoPackSlipQtyValid
    {
        int CoPackSlipQtyValidSp(QtyUnitType QtyRequired,
                                 QtyUnitType QtyToPack,
                                 StringType TPckCall,
                                 ref InfobarType Warning,
                                 ref InfobarType Infobar);
    }

    public class CoPackSlipQtyValid : ICoPackSlipQtyValid
    {
        readonly IApplicationDB appDB;

        public CoPackSlipQtyValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoPackSlipQtyValidSp(QtyUnitType QtyRequired,
                                        QtyUnitType QtyToPack,
                                        StringType TPckCall,
                                        ref InfobarType Warning,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoPackSlipQtyValidSp";

                appDB.AddCommandParameter(cmd, "QtyRequired", QtyRequired, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyToPack", QtyToPack, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TPckCall", TPckCall, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Warning", Warning, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
