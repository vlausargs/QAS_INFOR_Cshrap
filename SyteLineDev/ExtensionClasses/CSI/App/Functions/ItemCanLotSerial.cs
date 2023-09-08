//PROJECT NAME: Data
//CLASS NAME: ItemCanLotSerial.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemCanLotSerial : IItemCanLotSerial
	{
		readonly IApplicationDB appDB;
		
		public ItemCanLotSerial(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ItemCanLotSerialFn(
			string Item)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ItemCanLotSerial](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
