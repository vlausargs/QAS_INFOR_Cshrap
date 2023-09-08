//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetSROCustItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetSROCustItem : ISSSFSGetSROCustItem
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetSROCustItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSGetSROCustItemFn(
			string CustNum,
			string SRONum,
			string Item,
			string CustItem = null)
		{
			CustNumType _CustNum = CustNum;
			FSSRONumType _SRONum = SRONum;
			ItemType _Item = Item;
			CustItemType _CustItem = CustItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetSROCustItem](@CustNum, @SRONum, @Item, @CustItem)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
