//PROJECT NAME: Data
//CLASS NAME: ValidateHostPort.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateHostPort : IValidateHostPort
	{
		readonly IApplicationDB appDB;
		
		public ValidateHostPort(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ValidateHostPortSp(
			string PApsHostName,
			int? PApsPortNo,
			Guid? PRowPointer,
			string Infobar)
		{
			ApsHostnameType _PApsHostName = PApsHostName;
			ApsPortType _PApsPortNo = PApsPortNo;
			RowPointerType _PRowPointer = PRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateHostPortSp";
				
				appDB.AddCommandParameter(cmd, "PApsHostName", _PApsHostName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApsPortNo", _PApsPortNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRowPointer", _PRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
