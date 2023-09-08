//PROJECT NAME: CSICustomer
//CLASS NAME: CoLineRelWarehouseChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICoLineRelWarehouseChange
    {
        int CoLineRelWarehouseChangeSp(WhseType OldWhse,
                                       WhseType NewWhse,
                                       CoNumType StartingCoNum,
                                       CoNumType EndingCoNum,
                                       CoLineType StartingCoLine,
                                       CoLineType EndingCoLine,
                                       CoReleaseType StartingCoRelease,
                                       CoReleaseType EndingCoRelease,
                                       CustNumType StartingCustNum,
                                       CustNumType EndingCustNum,
                                       ref Infobar Infobar);
    }

    public class CoLineRelWarehouseChange : ICoLineRelWarehouseChange
    {
        readonly IApplicationDB appDB;

        public CoLineRelWarehouseChange(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoLineRelWarehouseChangeSp(WhseType OldWhse,
                                              WhseType NewWhse,
                                              CoNumType StartingCoNum,
                                              CoNumType EndingCoNum,
                                              CoLineType StartingCoLine,
                                              CoLineType EndingCoLine,
                                              CoReleaseType StartingCoRelease,
                                              CoReleaseType EndingCoRelease,
                                              CustNumType StartingCustNum,
                                              CustNumType EndingCustNum,
                                              ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoLineRelWarehouseChangeSp";

                appDB.AddCommandParameter(cmd, "OldWhse", OldWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewWhse", NewWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingCoNum", StartingCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingCoNum", EndingCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingCoLine", StartingCoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingCoLine", EndingCoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingCoRelease", StartingCoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingCoRelease", EndingCoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingCustNum", StartingCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingCustNum", EndingCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
