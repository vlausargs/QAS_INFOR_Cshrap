//PROJECT NAME: Logistics
//CLASS NAME: PmtpckCustomUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PmtpckCustomUpd : IPmtpckCustomUpd
	{
		readonly IApplicationDB appDB;


		public PmtpckCustomUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? PmtpckCustomUpdSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		string PInvNum,
		int? PInvSeq,
		int? PCheckSeq,
		string PSite,
		DateTime? PInvDate,
		DateTime? PDueDate,
		DateTime? PDiscDate,
		string PCoNum,
		string PArtranType,
		string PApplyCustNum,
		string PPayType,
		decimal? PTcAmtAmount,
		decimal? PTcAmtOrigAmt,
		decimal? PTcAmtTotPaid,
		decimal? PTcAmtAmtApplied,
		decimal? PTcAmtDiscAmt,
		decimal? PTcAmtAllowAmt,
		decimal? PDomAmtApplied,
		decimal? PDomDiscAmt,
		decimal? PDomAllowAmt,
		decimal? PForAmtApplied,
		decimal? PForDiscAmt,
		decimal? PForAllowAmt,
		int? PFixedRate,
		decimal? PExchRate,
		string PDescription,
		string PRef,
		int? PPickFlag,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string PDiscAcct,
		string PDiscAcctUnit1,
		string PDiscAcctUnit2,
		string PDiscAcctUnit3,
		string PDiscAcctUnit4,
		string PDoNum,
		int? PUseMultiDueDates,
		string PCreditMemoNum,
		Guid? PProcessId,
		decimal? PShipmentId,
		decimal? PTcAmtChargebackAmt,
		decimal? PDomChargebackAmt,
		decimal? PForChargebackAmt,
		string PTransactionCurrCode,
		decimal? PPaymentAmtApplied)
		{
			BankCodeType _PBankCode = PBankCode;
			CustNumType _PCustNum = PCustNum;
			ArpmtTypeType _PType = PType;
			ArCheckNumType _PCheckNum = PCheckNum;
			InvNumType _PInvNum = PInvNum;
			ArInvSeqType _PInvSeq = PInvSeq;
			ArCheckNumType _PCheckSeq = PCheckSeq;
			SiteType _PSite = PSite;
			DateType _PInvDate = PInvDate;
			DateType _PDueDate = PDueDate;
			DateType _PDiscDate = PDiscDate;
			CoNumType _PCoNum = PCoNum;
			ArtranTypeType _PArtranType = PArtranType;
			CustNumType _PApplyCustNum = PApplyCustNum;
			CustPayTypeType _PPayType = PPayType;
			AmountType _PTcAmtAmount = PTcAmtAmount;
			AmountType _PTcAmtOrigAmt = PTcAmtOrigAmt;
			AmountType _PTcAmtTotPaid = PTcAmtTotPaid;
			AmountType _PTcAmtAmtApplied = PTcAmtAmtApplied;
			AmountType _PTcAmtDiscAmt = PTcAmtDiscAmt;
			AmountType _PTcAmtAllowAmt = PTcAmtAllowAmt;
			AmountType _PDomAmtApplied = PDomAmtApplied;
			AmountType _PDomDiscAmt = PDomDiscAmt;
			AmountType _PDomAllowAmt = PDomAllowAmt;
			AmountType _PForAmtApplied = PForAmtApplied;
			AmountType _PForDiscAmt = PForDiscAmt;
			AmountType _PForAllowAmt = PForAllowAmt;
			ListYesNoType _PFixedRate = PFixedRate;
			ExchRateType _PExchRate = PExchRate;
			DescriptionType _PDescription = PDescription;
			ReferenceType _PRef = PRef;
			ListYesNoType _PPickFlag = PPickFlag;
			AcctType _PAcct = PAcct;
			UnitCode1Type _PAcctUnit1 = PAcctUnit1;
			UnitCode2Type _PAcctUnit2 = PAcctUnit2;
			UnitCode3Type _PAcctUnit3 = PAcctUnit3;
			UnitCode4Type _PAcctUnit4 = PAcctUnit4;
			AcctType _PDiscAcct = PDiscAcct;
			UnitCode1Type _PDiscAcctUnit1 = PDiscAcctUnit1;
			UnitCode2Type _PDiscAcctUnit2 = PDiscAcctUnit2;
			UnitCode3Type _PDiscAcctUnit3 = PDiscAcctUnit3;
			UnitCode4Type _PDiscAcctUnit4 = PDiscAcctUnit4;
			DoNumType _PDoNum = PDoNum;
			ListYesNoType _PUseMultiDueDates = PUseMultiDueDates;
			InvNumType _PCreditMemoNum = PCreditMemoNum;
			RowPointerType _PProcessId = PProcessId;
			ShipmentIDType _PShipmentId = PShipmentId;
			AmountType _PTcAmtChargebackAmt = PTcAmtChargebackAmt;
			AmountType _PDomChargebackAmt = PDomChargebackAmt;
			AmountType _PForChargebackAmt = PForChargebackAmt;
			CurrCodeType _PTransactionCurrCode = PTransactionCurrCode;
			AmountType _PPaymentAmtApplied = PPaymentAmtApplied;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmtpckCustomUpdSp";

				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvSeq", _PInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiscDate", _PDiscDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArtranType", _PArtranType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApplyCustNum", _PApplyCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcAmtAmount", _PTcAmtAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcAmtOrigAmt", _PTcAmtOrigAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcAmtTotPaid", _PTcAmtTotPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcAmtAmtApplied", _PTcAmtAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcAmtDiscAmt", _PTcAmtDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcAmtAllowAmt", _PTcAmtAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmtApplied", _PDomAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomDiscAmt", _PDomDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAllowAmt", _PDomAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmtApplied", _PForAmtApplied, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForDiscAmt", _PForDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAllowAmt", _PForAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDescription", _PDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRef", _PRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPickFlag", _PPickFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit1", _PAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit2", _PAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit3", _PAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctUnit4", _PAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiscAcct", _PDiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiscAcctUnit1", _PDiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiscAcctUnit2", _PDiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiscAcctUnit3", _PDiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiscAcctUnit4", _PDiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDoNum", _PDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUseMultiDueDates", _PUseMultiDueDates, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCreditMemoNum", _PCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShipmentId", _PShipmentId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTcAmtChargebackAmt", _PTcAmtChargebackAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomChargebackAmt", _PDomChargebackAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForChargebackAmt", _PForChargebackAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransactionCurrCode", _PTransactionCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPaymentAmtApplied", _PPaymentAmtApplied, ParameterDirection.Input);
				var Severity = appDB.ExecuteNonQuery(cmd);

				return (Severity);
			}
		}
	}
}
