//PROJECT NAME: Data
//CLASS NAME: GetExpiredLotQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetExpiredLotQty : IGetExpiredLotQty
	{
		readonly IApplicationDB appDB;
		
		public GetExpiredLotQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetExpiredLotQtyFn(
			string Item,
			DateTime? CutoffDate,
			string Whse)
		{
			ItemType _Item = Item;
			DateTimeType _CutoffDate = CutoffDate;
			WhseType _Whse = Whse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetExpiredLotQty](@Item, @CutoffDate, @Whse)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
