//PROJECT NAME: Data
//CLASS NAME: MaxQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class MaxQty : IMaxQty
	{
		readonly IApplicationDB appDB;


		public MaxQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public decimal? MaxQtyFn(decimal? Qty1,
		decimal? Qty2)
		{
			QtyTotlType _Qty1 = Qty1;
			QtyTotlType _Qty2 = Qty2;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaxQty](@Qty1, @Qty2)";

				appDB.AddCommandParameter(cmd, "Qty1", _Qty1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty2", _Qty2, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}

		public decimal? MaxQtySp(
			decimal? Qty1,
			decimal? Qty2)
		{
			QtyUnitType _Qty1 = Qty1;
			QtyUnitType _Qty2 = Qty2;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaxQtySp](@Qty1, @Qty2)";

				appDB.AddCommandParameter(cmd, "Qty1", _Qty1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty2", _Qty2, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}
	}
}
