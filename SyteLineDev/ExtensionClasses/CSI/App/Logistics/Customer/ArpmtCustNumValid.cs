//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtCustNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IArpmtCustNumValid
	{
		(int? ReturnCode, string PCustNum, int? PCorpCust, string PCustName, string PType, string PBankCode, string PCustCurr, int? PBnkCurrPartOfEuro, int? PFixedEuro, string PBankCurrCode, DateTime? PRecptDate, decimal? PExchRate, string BankAmtFormat, int? PDraftPrint, string PPayCurrCode, string PPayAmtFormat, decimal? PPaymentExchRate, string Infobar) ArpmtCustNumValidSp(string PCustNum,
		int? PCheckNum,
		int? PCorpCust,
		string PCustName,
		string PType,
		string PBankCode,
		string PCustCurr,
		int? PBnkCurrPartOfEuro,
		int? PFixedEuro,
		string PBankCurrCode,
		DateTime? PRecptDate,
		decimal? PExchRate,
		string BankAmtFormat = null,
		int? PDraftPrint = null,
		string PPayCurrCode = null,
		string PPayAmtFormat = null,
		decimal? PPaymentExchRate = null,
		string Infobar = null);
	}
	
	public class ArpmtCustNumValid : IArpmtCustNumValid
	{
		readonly IApplicationDB appDB;
		
		public ArpmtCustNumValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PCustNum, int? PCorpCust, string PCustName, string PType, string PBankCode, string PCustCurr, int? PBnkCurrPartOfEuro, int? PFixedEuro, string PBankCurrCode, DateTime? PRecptDate, decimal? PExchRate, string BankAmtFormat, int? PDraftPrint, string PPayCurrCode, string PPayAmtFormat, decimal? PPaymentExchRate, string Infobar) ArpmtCustNumValidSp(string PCustNum,
		int? PCheckNum,
		int? PCorpCust,
		string PCustName,
		string PType,
		string PBankCode,
		string PCustCurr,
		int? PBnkCurrPartOfEuro,
		int? PFixedEuro,
		string PBankCurrCode,
		DateTime? PRecptDate,
		decimal? PExchRate,
		string BankAmtFormat = null,
		int? PDraftPrint = null,
		string PPayCurrCode = null,
		string PPayAmtFormat = null,
		decimal? PPaymentExchRate = null,
		string Infobar = null)
		{
			CustNumType _PCustNum = PCustNum;
			ArCheckNumType _PCheckNum = PCheckNum;
			FlagNyType _PCorpCust = PCorpCust;
			NameType _PCustName = PCustName;
			CustPayTypeType _PType = PType;
			BankCodeType _PBankCode = PBankCode;
			CurrCodeType _PCustCurr = PCustCurr;
			FlagNyType _PBnkCurrPartOfEuro = PBnkCurrPartOfEuro;
			FlagNyType _PFixedEuro = PFixedEuro;
			CurrCodeType _PBankCurrCode = PBankCurrCode;
			DateType _PRecptDate = PRecptDate;
			ExchRateType _PExchRate = PExchRate;
			InputMaskType _BankAmtFormat = BankAmtFormat;
			ListYesNoType _PDraftPrint = PDraftPrint;
			CurrCodeType _PPayCurrCode = PPayCurrCode;
			InputMaskType _PPayAmtFormat = PPayAmtFormat;
			ExchRateType _PPaymentExchRate = PPaymentExchRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtCustNumValidSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCorpCust", _PCorpCust, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCustName", _PCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCustCurr", _PCustCurr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBnkCurrPartOfEuro", _PBnkCurrPartOfEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFixedEuro", _PFixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBankCurrCode", _PBankCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRecptDate", _PRecptDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BankAmtFormat", _BankAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDraftPrint", _PDraftPrint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayCurrCode", _PPayCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayAmtFormat", _PPayAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPaymentExchRate", _PPaymentExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCustNum = _PCustNum;
				PCorpCust = _PCorpCust;
				PCustName = _PCustName;
				PType = _PType;
				PBankCode = _PBankCode;
				PCustCurr = _PCustCurr;
				PBnkCurrPartOfEuro = _PBnkCurrPartOfEuro;
				PFixedEuro = _PFixedEuro;
				PBankCurrCode = _PBankCurrCode;
				PRecptDate = _PRecptDate;
				PExchRate = _PExchRate;
				BankAmtFormat = _BankAmtFormat;
				PDraftPrint = _PDraftPrint;
				PPayCurrCode = _PPayCurrCode;
				PPayAmtFormat = _PPayAmtFormat;
				PPaymentExchRate = _PPaymentExchRate;
				Infobar = _Infobar;
				
				return (Severity, PCustNum, PCorpCust, PCustName, PType, PBankCode, PCustCurr, PBnkCurrPartOfEuro, PFixedEuro, PBankCurrCode, PRecptDate, PExchRate, BankAmtFormat, PDraftPrint, PPayCurrCode, PPayAmtFormat, PPaymentExchRate, Infobar);
			}
		}
	}
}
