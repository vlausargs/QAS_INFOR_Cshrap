//PROJECT NAME: Data
//CLASS NAME: GetItemOrCustItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetItemOrCustItem : IGetItemOrCustItem
	{
		readonly IApplicationDB appDB;
		
		public GetItemOrCustItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetItemOrCustItemFn(
			string CustItem,
			string Item)
		{
			ItemType _CustItem = CustItem;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetItemOrCustItem](@CustItem, @Item)";
				
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
