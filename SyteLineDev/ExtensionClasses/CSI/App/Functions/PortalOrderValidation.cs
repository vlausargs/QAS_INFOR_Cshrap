//PROJECT NAME: Data
//CLASS NAME: PortalOrderValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PortalOrderValidation : IPortalOrderValidation
	{
		readonly IApplicationDB appDB;
		
		public PortalOrderValidation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? pCreditLimitExceeded,
			int? pOrderCreditLimitExceeded,
			string pCorpCredCustNum,
			int? pOnCreditHold,
			string Infobar) PortalOrderValidationSp(
			string pCustNum,
			string pCoNum,
			int? pCreditLimitExceeded,
			int? pOrderCreditLimitExceeded,
			string pCorpCredCustNum,
			int? pOnCreditHold,
			string Infobar)
		{
			CustNumType _pCustNum = pCustNum;
			CoNumType _pCoNum = pCoNum;
			ListYesNoType _pCreditLimitExceeded = pCreditLimitExceeded;
			ListYesNoType _pOrderCreditLimitExceeded = pOrderCreditLimitExceeded;
			CustNumType _pCorpCredCustNum = pCorpCredCustNum;
			ListYesNoType _pOnCreditHold = pOnCreditHold;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalOrderValidationSp";
				
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditLimitExceeded", _pCreditLimitExceeded, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pOrderCreditLimitExceeded", _pOrderCreditLimitExceeded, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCorpCredCustNum", _pCorpCredCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pOnCreditHold", _pOnCreditHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pCreditLimitExceeded = _pCreditLimitExceeded;
				pOrderCreditLimitExceeded = _pOrderCreditLimitExceeded;
				pCorpCredCustNum = _pCorpCredCustNum;
				pOnCreditHold = _pOnCreditHold;
				Infobar = _Infobar;
				
				return (Severity, pCreditLimitExceeded, pOrderCreditLimitExceeded, pCorpCredCustNum, pOnCreditHold, Infobar);
			}
		}
	}
}
