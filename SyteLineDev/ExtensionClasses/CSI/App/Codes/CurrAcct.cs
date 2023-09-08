//PROJECT NAME: Codes
//CLASS NAME: CurrAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CurrAcct : ICurrAcct
	{
		readonly IApplicationDB appDB;
		
		
		public CurrAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? IsRecordCreated,
		DateTime? NewRecordDate,
		Guid? NewRowPointer) CurrAcctSp(string CurrCode,
		int? IsRecordCreated,
		DateTime? NewRecordDate,
		Guid? NewRowPointer)
		{
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _IsRecordCreated = IsRecordCreated;
			DateType _NewRecordDate = NewRecordDate;
			RowPointerType _NewRowPointer = NewRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CurrAcctSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsRecordCreated", _IsRecordCreated, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewRecordDate", _NewRecordDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NewRowPointer", _NewRowPointer, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IsRecordCreated = _IsRecordCreated;
				NewRecordDate = _NewRecordDate;
				NewRowPointer = _NewRowPointer;
				
				return (Severity, IsRecordCreated, NewRecordDate, NewRowPointer);
			}
		}
	}
}
