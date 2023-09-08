//PROJECT NAME: Data
//CLASS NAME: MinQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class MinQty : IMinQty
    {
        readonly IApplicationDB appDB;


        public MinQty(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public decimal? MinQtyFn(
            decimal? Qty1,
            decimal? Qty2)
        {
            QtyUnitType _Qty1 = Qty1;
            QtyUnitType _Qty2 = Qty2;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[MinQty](@Qty1, @Qty2)";

                appDB.AddCommandParameter(cmd, "Qty1", _Qty1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Qty2", _Qty2, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<decimal?>(cmd);

                return Output;
            }
        }

        public decimal? MinQtySp(
            decimal? Qty1,
            decimal? Qty2)
        {
            QtyUnitType _Qty1 = Qty1;
            QtyUnitType _Qty2 = Qty2;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[MinQtySp](@Qty1, @Qty2)";

                appDB.AddCommandParameter(cmd, "Qty1", _Qty1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Qty2", _Qty2, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<decimal?>(cmd);

                return Output;
            }
        }
    }
}
