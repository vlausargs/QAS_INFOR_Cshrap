//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitCopy : ISSSFSUnitCopy
	{
		readonly IApplicationDB appDB;
		
		public SSSFSUnitCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSUnitCopySp(
			string iCopyToSerNum,
			string iCopyFromSerNum,
			int? iAppend = 0,
			int? iParentID = null,
			string iCopyFromItem = null,
			string iCopyToItem = null,
			DateTime? iInstallDate = null)
		{
			SerNumType _iCopyToSerNum = iCopyToSerNum;
			SerNumType _iCopyFromSerNum = iCopyFromSerNum;
			ListYesNoType _iAppend = iAppend;
			FSCompIdType _iParentID = iParentID;
			ItemType _iCopyFromItem = iCopyFromItem;
			ItemType _iCopyToItem = iCopyToItem;
			DateTimeType _iInstallDate = iInstallDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSUnitCopy";
				
				appDB.AddCommandParameter(cmd, "iCopyToSerNum", _iCopyToSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCopyFromSerNum", _iCopyFromSerNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iAppend", _iAppend, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iParentID", _iParentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCopyFromItem", _iCopyFromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iCopyToItem", _iCopyToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iInstallDate", _iInstallDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
