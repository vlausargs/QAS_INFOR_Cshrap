//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigSearchGetUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigSearchGetUnit : ISSSFSConfigSearchGetUnit
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConfigSearchGetUnit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string SerNum,
			string Item) SSSFSConfigSearchGetUnitSp(
			int? CompId,
			string SerNum,
			string Item)
		{
			FSCompIdType _CompId = CompId;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConfigSearchGetUnitSp";
				
				appDB.AddCommandParameter(cmd, "CompId", _CompId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerNum = _SerNum;
				Item = _Item;
				
				return (Severity, SerNum, Item);
			}
		}
	}
}
