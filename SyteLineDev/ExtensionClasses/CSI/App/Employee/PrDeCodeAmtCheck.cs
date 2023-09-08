//PROJECT NAME: Employee
//CLASS NAME: PrDeCodeAmtCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PrDeCodeAmtCheck : IPrDeCodeAmtCheck
	{
		readonly IApplicationDB appDB;
		
		
		public PrDeCodeAmtCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PrDeCodeAmtCheckSp(string pEmpNum,
		int? pEmpSeq,
		string pPrDeCode,
		decimal? pPrDeAmt,
		int? pDeCodeSeq,
		string Infobar)
		{
			EmpNumType _pEmpNum = pEmpNum;
			PrtrxSeqType _pEmpSeq = pEmpSeq;
			DeCodeType _pPrDeCode = pPrDeCode;
			PrAmountType _pPrDeAmt = pPrDeAmt;
			IntType _pDeCodeSeq = pDeCodeSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrDeCodeAmtCheckSp";
				
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpSeq", _pEmpSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrDeCode", _pPrDeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrDeAmt", _pPrDeAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDeCodeSeq", _pDeCodeSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
