//PROJECT NAME: Data
//CLASS NAME: ItemAvailTotalQtyOnHandForTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemAvailTotalQtyOnHandForTrans : IItemAvailTotalQtyOnHandForTrans
	{
		readonly IApplicationDB appDB;
		
		public ItemAvailTotalQtyOnHandForTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ItemAvailTotalQtyOnHandForTransFn(
			string Item,
			string Whse,
			string Loc,
			string Lot)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			LocType _Loc = Loc;
			LotType _Lot = Lot;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemAvailTotalQtyOnHandForTrans](@Item, @Whse, @Loc, @Lot)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
