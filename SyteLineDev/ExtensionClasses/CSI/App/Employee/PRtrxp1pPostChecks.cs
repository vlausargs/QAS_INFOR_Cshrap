//PROJECT NAME: Employee
//CLASS NAME: PRtrxp1pPostChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PRtrxp1pPostChecks : IPRtrxp1pPostChecks
	{
		readonly IApplicationDB appDB;
		
		
		public PRtrxp1pPostChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PRtrxp1pPostChecksSp(Guid? pSessionID,
		Guid? pPrtrxRowPointer,
		string Infobar)
		{
			RowPointerType _pSessionID = pSessionID;
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PRtrxp1pPostChecksSp";
				
				appDB.AddCommandParameter(cmd, "pSessionID", _pSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
