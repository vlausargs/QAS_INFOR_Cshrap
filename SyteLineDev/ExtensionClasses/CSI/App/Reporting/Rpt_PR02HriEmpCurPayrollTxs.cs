//PROJECT NAME: Reporting
//CLASS NAME: RPT_PR02HriEmpCurPayrollTxs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_PR02HriEmpCurPayrollTxs : IRPT_PR02HriEmpCurPayrollTxs
	{
		readonly IApplicationDB appDB;
		
		public RPT_PR02HriEmpCurPayrollTxs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RPT_PR02HriEmpCurPayrollTxsSp(
			Guid? pPrtrxRowPointer,
			int? pIdx,
			string pListTDe,
			string pListTAmt,
			int? pTCanCost,
			string Infobar)
		{
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			IntType _pIdx = pIdx;
			LongListType _pListTDe = pListTDe;
			LongListType _pListTAmt = pListTAmt;
			ListYesNoType _pTCanCost = pTCanCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_PR02HriEmpCurPayrollTxsSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
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
