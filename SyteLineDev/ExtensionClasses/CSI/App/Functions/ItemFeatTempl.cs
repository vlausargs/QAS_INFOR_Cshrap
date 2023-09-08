//PROJECT NAME: Data
//CLASS NAME: ItemFeatTempl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemFeatTempl : IItemFeatTempl
	{
		readonly IApplicationDB appDB;
		
		public ItemFeatTempl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ItemFeatTemplFn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemFeatTempl](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
