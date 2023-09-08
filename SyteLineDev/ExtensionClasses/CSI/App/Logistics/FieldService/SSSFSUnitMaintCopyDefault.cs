//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitMaintCopyDefault.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitMaintCopyDefault : ISSSFSUnitMaintCopyDefault
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitMaintCopyDefault(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSUnitMaintCopyDefaultSP(
			string InItem,
			string InSerNum)
		{
			ItemType _InItem = InItem;
			SerNumType _InSerNum = InSerNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitMaintCopyDefaultSP";
				
				appDB.AddCommandParameter(cmd, "InItem", _InItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSerNum", _InSerNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
