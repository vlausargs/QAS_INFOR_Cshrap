//PROJECT NAME: Data
//CLASS NAME: PRtrxp1pUpdPostChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PRtrxp1pUpdPostChecks : IPRtrxp1pUpdPostChecks
	{
		readonly IApplicationDB appDB;
		
		public PRtrxp1pUpdPostChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PRtrxp1pUpdPostChecksSp(
			Guid? pPrtrxRowPointer,
			Guid? pEmployeeRowPointer,
			decimal? pEmployeeYtdEmpCon,
			string pListPrtrxDeCode,
			string pListPrtrxDeAmt,
			string Infobar)
		{
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			RowPointerType _pEmployeeRowPointer = pEmployeeRowPointer;
			PrAmountType _pEmployeeYtdEmpCon = pEmployeeYtdEmpCon;
			LongListType _pListPrtrxDeCode = pListPrtrxDeCode;
			LongListType _pListPrtrxDeAmt = pListPrtrxDeAmt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PRtrxp1pUpdPostChecksSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmployeeRowPointer", _pEmployeeRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmployeeYtdEmpCon", _pEmployeeYtdEmpCon, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pListPrtrxDeCode", _pListPrtrxDeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pListPrtrxDeAmt", _pListPrtrxDeAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
