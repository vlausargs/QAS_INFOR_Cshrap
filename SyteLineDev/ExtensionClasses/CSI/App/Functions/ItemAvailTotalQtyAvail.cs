//PROJECT NAME: Data
//CLASS NAME: ItemAvailTotalQtyAvail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemAvailTotalQtyAvail : IItemAvailTotalQtyAvail
	{
		readonly IApplicationDB appDB;
		
		public ItemAvailTotalQtyAvail(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ItemAvailTotalQtyAvailFn(
			string Item,
			string Site)
		{
			ItemType _Item = Item;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemAvailTotalQtyAvail](@Item, @Site)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
