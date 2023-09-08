//PROJECT NAME: Reporting
//CLASS NAME: RPT_PRtrxp1pPostChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_PRtrxp1pPostChecks : IRPT_PRtrxp1pPostChecks
	{
		readonly IApplicationDB appDB;
		
		public RPT_PRtrxp1pPostChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RPT_PRtrxp1pPostChecksSp(
			Guid? pPrtrxRowPointer,
			string pSessionIDChar = null,
			string Infobar = null)
		{
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			StringType _pSessionIDChar = pSessionIDChar;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_PRtrxp1pPostChecksSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSessionIDChar", _pSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
