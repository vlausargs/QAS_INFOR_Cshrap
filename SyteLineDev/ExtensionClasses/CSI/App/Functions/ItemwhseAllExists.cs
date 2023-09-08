//PROJECT NAME: Data
//CLASS NAME: ItemwhseAllExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemwhseAllExists : IItemwhseAllExists
	{
		readonly IApplicationDB appDB;
		
		public ItemwhseAllExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ItemwhseAllExistsFn(
			string Item,
			string Whse,
			string Site)
		{
			ItemType _Item = Item;
			WhseType _Whse = Whse;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemwhseAllExists](@Item, @Whse, @Site)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
