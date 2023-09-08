//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateLinesCheckForRecalc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEstimateLinesCheckForRecalc
    {
        int EstimateLinesCheckForRecalcSp(UMType PNewUM,
                                          ItemType PItem,
                                          ref Infobar Infobar,
                                          ref Infobar Infobtn);
    }

    public class EstimateLinesCheckForRecalc : IEstimateLinesCheckForRecalc
    {
        readonly IApplicationDB appDB;

        public EstimateLinesCheckForRecalc(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EstimateLinesCheckForRecalcSp(UMType PNewUM,
                                                 ItemType PItem,
                                                 ref Infobar Infobar,
                                                 ref Infobar Infobtn)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EstimateLinesCheckForRecalcSp";

                appDB.AddCommandParameter(cmd, "PNewUM", PNewUM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobtn", Infobtn, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
