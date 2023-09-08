//PROJECT NAME: Data
//CLASS NAME: MinAmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class MinAmt : IMinAmt
    {
        readonly IApplicationDB appDB;


        public MinAmt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public decimal? MinAmtFn(
            decimal? Amt1,
            decimal? Amt2)
        {
            GenericDecimalType _Amt1 = Amt1;
            GenericDecimalType _Amt2 = Amt2;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[MinAmt](@Amt1, @Amt2)";

                appDB.AddCommandParameter(cmd, "Amt1", _Amt1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Amt2", _Amt2, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<decimal?>(cmd);

                return Output;
            }
        }
    }
}
