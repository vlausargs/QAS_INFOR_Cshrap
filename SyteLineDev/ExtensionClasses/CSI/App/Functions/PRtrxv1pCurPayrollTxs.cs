//PROJECT NAME: Data
//CLASS NAME: PRtrxv1pCurPayrollTxs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PRtrxv1pCurPayrollTxs : IPRtrxv1pCurPayrollTxs
	{
		readonly IApplicationDB appDB;
		
		public PRtrxv1pCurPayrollTxs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? rTFreqMult,
			int? rErrorOccurred,
			string Infobar) PRtrxv1pCurPayrollTxsSp(
			Guid? pPrtrxRowPointer,
			Guid? pFedRowPointer,
			string pBankHdrBankCode,
			decimal? rTFreqMult,
			int? rErrorOccurred,
			string Infobar,
			string DeptUnit)
		{
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			RowPointerType _pFedRowPointer = pFedRowPointer;
			BankCodeType _pBankHdrBankCode = pBankHdrBankCode;
			GenericDecimalType _rTFreqMult = rTFreqMult;
			FlagNyType _rErrorOccurred = rErrorOccurred;
			InfobarType _Infobar = Infobar;
			UnitCode1Type _DeptUnit = DeptUnit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PRtrxv1pCurPayrollTxsSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFedRowPointer", _pFedRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankHdrBankCode", _pBankHdrBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rTFreqMult", _rTFreqMult, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "rErrorOccurred", _rErrorOccurred, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DeptUnit", _DeptUnit, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rTFreqMult = _rTFreqMult;
				rErrorOccurred = _rErrorOccurred;
				Infobar = _Infobar;
				
				return (Severity, rTFreqMult, rErrorOccurred, Infobar);
			}
		}
	}
}
