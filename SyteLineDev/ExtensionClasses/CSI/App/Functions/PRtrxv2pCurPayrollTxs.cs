//PROJECT NAME: Data
//CLASS NAME: PRtrxv2pCurPayrollTxs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PRtrxv2pCurPayrollTxs : IPRtrxv2pCurPayrollTxs
	{
		readonly IApplicationDB appDB;
		
		public PRtrxv2pCurPayrollTxs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? rErrorOccurred,
			string Infobar) PRtrxv2pCurPayrollTxsSp(
			Guid? pPrtrxRowPointer,
			int? rErrorOccurred,
			string Infobar,
			string DeptUnit)
		{
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			FlagNyType _rErrorOccurred = rErrorOccurred;
			InfobarType _Infobar = Infobar;
			UnitCode1Type _DeptUnit = DeptUnit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PRtrxv2pCurPayrollTxsSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rErrorOccurred", _rErrorOccurred, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeptUnit", _DeptUnit, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rErrorOccurred = _rErrorOccurred;
				Infobar = _Infobar;
				
				return (Severity, rErrorOccurred, Infobar);
			}
		}
	}
}
