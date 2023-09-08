//PROJECT NAME: Finance
//CLASS NAME: ArpmtdGetExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ArpmtdGetExchRate : IArpmtdGetExchRate
	{
		readonly IApplicationDB appDB;
		
		public ArpmtdGetExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PRate,
			int? PUpdateRate) ArpmtdGetExchRateSp(
			string PArpmtdSite,
			int? PAddMode,
			string PArpmtdType,
			decimal? PArpmtdExchRate,
			decimal? PArpmtExchRate,
			string PArpmtCustNum,
			string PArpmtdInvNum,
			decimal? PRate,
			int? PUpdateRate,
			string PCustCurrCode = null,
			string PArpmtBankCode = null,
			string PArpmtPaymentCurrCode = null,
			decimal? PArpmtPaymentExchRate = null)
		{
			SiteType _PArpmtdSite = PArpmtdSite;
			FlagNyType _PAddMode = PAddMode;
			StringType _PArpmtdType = PArpmtdType;
			ExchRateType _PArpmtdExchRate = PArpmtdExchRate;
			ExchRateType _PArpmtExchRate = PArpmtExchRate;
			CustNumType _PArpmtCustNum = PArpmtCustNum;
			InvNumType _PArpmtdInvNum = PArpmtdInvNum;
			ExchRateType _PRate = PRate;
			FlagNyType _PUpdateRate = PUpdateRate;
			CurrCodeType _PCustCurrCode = PCustCurrCode;
			BankCodeType _PArpmtBankCode = PArpmtBankCode;
			CurrCodeType _PArpmtPaymentCurrCode = PArpmtPaymentCurrCode;
			ExchRateType _PArpmtPaymentExchRate = PArpmtPaymentExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdGetExchRateSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtdSite", _PArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddMode", _PAddMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdType", _PArpmtdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdExchRate", _PArpmtdExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtExchRate", _PArpmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtCustNum", _PArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdInvNum", _PArpmtdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRate", _PRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUpdateRate", _PUpdateRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCustCurrCode", _PCustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtBankCode", _PArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtPaymentCurrCode", _PArpmtPaymentCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtPaymentExchRate", _PArpmtPaymentExchRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PRate = _PRate;
				PUpdateRate = _PUpdateRate;
				
				return (Severity, PRate, PUpdateRate);
			}
		}
	}
}
