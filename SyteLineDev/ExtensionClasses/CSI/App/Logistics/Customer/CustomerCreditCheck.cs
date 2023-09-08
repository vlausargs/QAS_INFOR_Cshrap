//PROJECT NAME: Logistics
//CLASS NAME: CustomerCreditCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CustomerCreditCheck : ICustomerCreditCheck
	{
		readonly IApplicationDB appDB;
		
		
		public CustomerCreditCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pCreditLimitExceeded,
		decimal? pCreditLimit,
		decimal? pCreditLimitBalance,
		string pCurrencyCode,
		int? pOnCreditHold,
		string pCreditHoldReason,
		int? pLCRRequired,
		string Infobar) CustomerCreditCheckSp(string pSite,
		string pCustNum,
		decimal? pAmount,
		int? pCreditLimitExceeded,
		decimal? pCreditLimit,
		decimal? pCreditLimitBalance,
		string pCurrencyCode,
		int? pOnCreditHold,
		string pCreditHoldReason,
		int? pLCRRequired,
		string Infobar)
		{
			SiteType _pSite = pSite;
			CustNumType _pCustNum = pCustNum;
			AmountType _pAmount = pAmount;
			ListYesNoType _pCreditLimitExceeded = pCreditLimitExceeded;
			AmountType _pCreditLimit = pCreditLimit;
			AmountType _pCreditLimitBalance = pCreditLimitBalance;
			CurrCodeType _pCurrencyCode = pCurrencyCode;
			ListYesNoType _pOnCreditHold = pOnCreditHold;
			ReasonCodeType _pCreditHoldReason = pCreditHoldReason;
			ListYesNoType _pLCRRequired = pLCRRequired;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerCreditCheckSp";
				
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustNum", _pCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAmount", _pAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreditLimitExceeded", _pCreditLimitExceeded, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCreditLimit", _pCreditLimit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCreditLimitBalance", _pCreditLimitBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurrencyCode", _pCurrencyCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pOnCreditHold", _pOnCreditHold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCreditHoldReason", _pCreditHoldReason, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pLCRRequired", _pLCRRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pCreditLimitExceeded = _pCreditLimitExceeded;
				pCreditLimit = _pCreditLimit;
				pCreditLimitBalance = _pCreditLimitBalance;
				pCurrencyCode = _pCurrencyCode;
				pOnCreditHold = _pOnCreditHold;
				pCreditHoldReason = _pCreditHoldReason;
				pLCRRequired = _pLCRRequired;
				Infobar = _Infobar;
				
				return (Severity, pCreditLimitExceeded, pCreditLimit, pCreditLimitBalance, pCurrencyCode, pOnCreditHold, pCreditHoldReason, pLCRRequired, Infobar);
			}
		}
	}
}
