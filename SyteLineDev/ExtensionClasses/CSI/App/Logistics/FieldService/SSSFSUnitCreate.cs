//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitCreate : ISSSFSUnitCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSUnitCreateSp(
			string InSerNum,
			string InItem,
			DateTime? InCreateDate,
			int? InCompID = 0,
			int? BufferMode = 0)
		{
			SerNumType _InSerNum = InSerNum;
			ItemType _InItem = InItem;
			CurrentDateType _InCreateDate = InCreateDate;
			FSCompIdType _InCompID = InCompID;
			ListYesNoType _BufferMode = BufferMode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitCreateSp";
				
				appDB.AddCommandParameter(cmd, "InSerNum", _InSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InItem", _InItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCreateDate", _InCreateDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InCompID", _InCompID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BufferMode", _BufferMode, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
