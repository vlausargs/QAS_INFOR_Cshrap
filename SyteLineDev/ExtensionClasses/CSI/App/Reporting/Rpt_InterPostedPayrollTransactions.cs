//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InterPostedPayrollTransactions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_InterPostedPayrollTransactions : IRpt_InterPostedPayrollTransactions
	{
		readonly IApplicationDB appDB;
		
		public Rpt_InterPostedPayrollTransactions(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Rpt_InterPostedPayrollTransactionsSp(
			Guid? pPrtrxpRowPointer,
			int? pIdx,
			string pListTDe,
			string pListTAmt,
			int? pTCanCost,
			string Infobar)
		{
			RowPointerType _pPrtrxpRowPointer = pPrtrxpRowPointer;
			IntType _pIdx = pIdx;
			LongListType _pListTDe = pListTDe;
			LongListType _pListTAmt = pListTAmt;
			ListYesNoType _pTCanCost = pTCanCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InterPostedPayrollTransactionsSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxpRowPointer", _pPrtrxpRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIdx", _pIdx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pListTDe", _pListTDe, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pListTAmt", _pListTAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTCanCost", _pTCanCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
