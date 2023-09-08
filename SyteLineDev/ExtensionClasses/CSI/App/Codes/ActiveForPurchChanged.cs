//PROJECT NAME: CSICodes
//CLASS NAME: ActiveForPurchChanged.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IActiveForPurchChanged
    {
        int ActiveForPurchChangedSp(StringType ActiveForPurch,
                                    TaxSystemType TaxSystem,
                                    ref InfobarType Infobar);
    }

    public class ActiveForPurchChanged : IActiveForPurchChanged
    {
        readonly IApplicationDB appDB;

        public ActiveForPurchChanged(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ActiveForPurchChangedSp(StringType ActiveForPurch,
                                           TaxSystemType TaxSystem,
                                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActiveForPurchChangedSp";

                appDB.AddCommandParameter(cmd, "ActiveForPurch", ActiveForPurch, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxSystem", TaxSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
