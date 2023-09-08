//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigSearchAddUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigSearchAddUnit : ISSSFSConfigSearchAddUnit
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConfigSearchAddUnit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConfigSearchAddUnitSp(
			string SerNum,
			string Item)
		{
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConfigSearchAddUnitSp";
				
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
