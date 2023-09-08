//PROJECT NAME: Logistics
//CLASS NAME: EDICustBOrderItemUM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EDICustBOrderItemUM : IEDICustBOrderItemUM
	{
		readonly IApplicationDB appDB;
		
		
		public EDICustBOrderItemUM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ItemUM) EDICustBOrderItemUMSp(string Item,
		string CustNum,
		string ItemUM)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			UMType _ItemUM = ItemUM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EDICustBOrderItemUMSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ItemUM = _ItemUM;
				
				return (Severity, ItemUM);
			}
		}
	}
}
