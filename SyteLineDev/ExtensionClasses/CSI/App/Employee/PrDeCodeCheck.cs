//PROJECT NAME: Employee
//CLASS NAME: PrDeCodeCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class PrDeCodeCheck : IPrDeCodeCheck
	{
		readonly IApplicationDB appDB;
		
		
		public PrDeCodeCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PrDeCodeCheckSp(string pEmpNum,
		int? pEmpSeq,
		string pPrDeCode,
		decimal? pPrDeAmt,
		int? pDeCodeSeq,
		string PEmpType,
		string Infobar)
		{
			EmpNumType _pEmpNum = pEmpNum;
			PrtrxSeqType _pEmpSeq = pEmpSeq;
			DeCodeType _pPrDeCode = pPrDeCode;
			PrAmountType _pPrDeAmt = pPrDeAmt;
			IntType _pDeCodeSeq = pDeCodeSeq;
			EmpTypeType _PEmpType = PEmpType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrDeCodeCheckSp";
				
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpSeq", _pEmpSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrDeCode", _pPrDeCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrDeAmt", _pPrDeAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDeCodeSeq", _pDeCodeSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEmpType", _PEmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
