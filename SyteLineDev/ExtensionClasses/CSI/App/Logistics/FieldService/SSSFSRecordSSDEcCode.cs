//PROJECT NAME: Logistics
//CLASS NAME: SSSFSRecordSSDEcCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSRecordSSDEcCode : ISSSFSRecordSSDEcCode
	{
		readonly IApplicationDB appDB;
		
		public SSSFSRecordSSDEcCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) SSSFSRecordSSDEcCodeSp(
			Guid? iRowPointer,
			int? iLineTrans,
			string iMode,
			string Infobar)
		{
			RowPointerType _iRowPointer = iRowPointer;
			ListYesNoType _iLineTrans = iLineTrans;
			UnusedCharType _iMode = iMode;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRecordSSDEcCodeSp";
				
				appDB.AddCommandParameter(cmd, "iRowPointer", _iRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iLineTrans", _iLineTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iMode", _iMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
