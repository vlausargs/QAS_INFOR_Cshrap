//PROJECT NAME: CSICustomer
//CLASS NAME: AddSingleByPOFilter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IAddSingleByPOFilter
    {
        int AddSingleByPOFilterSp(string PDoNum,
                                  ref string PPOFilter,
                                  ref string Infobar);
    }

    public class AddSingleByPOFilter : IAddSingleByPOFilter
    {
        readonly IApplicationDB appDB;

        public AddSingleByPOFilter(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AddSingleByPOFilterSp(string PDoNum,
                                         ref string PPOFilter,
                                         ref string Infobar)
        {
            DoNumType _PDoNum = PDoNum;
            InfobarType _PPOFilter = PPOFilter;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AddSingleByPOFilterSp";

                appDB.AddCommandParameter(cmd, "PDoNum", _PDoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPOFilter", _PPOFilter, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PPOFilter = _PPOFilter;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
