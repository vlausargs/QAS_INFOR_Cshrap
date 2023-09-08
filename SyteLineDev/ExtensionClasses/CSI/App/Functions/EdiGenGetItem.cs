//PROJECT NAME: Data
//CLASS NAME: EdiGenGetItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiGenGetItem : IEdiGenGetItem
	{
		readonly IApplicationDB appDB;
		
		public EdiGenGetItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PError,
			Guid? PItemRecid,
			Guid? PItemcustRecid) EdiGenGetItemSp(
			string PItem,
			string PCustNum,
			string PCustItem,
			int? PError,
			Guid? PItemRecid,
			Guid? PItemcustRecid)
		{
			ItemType _PItem = PItem;
			CustNumType _PCustNum = PCustNum;
			CustItemType _PCustItem = PCustItem;
			FlagNyType _PError = PError;
			RowPointerType _PItemRecid = PItemRecid;
			RowPointerType _PItemcustRecid = PItemcustRecid;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EdiGenGetItemSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustItem", _PCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PError", _PError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemRecid", _PItemRecid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PItemcustRecid", _PItemcustRecid, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PError = _PError;
				PItemRecid = _PItemRecid;
				PItemcustRecid = _PItemcustRecid;
				
				return (Severity, PError, PItemRecid, PItemcustRecid);
			}
		}
	}
}
