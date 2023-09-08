//PROJECT NAME: Logistics
//CLASS NAME: APQPCustUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class APQPCustUpd : IAPQPCustUpd
	{
		readonly IApplicationDB appDB;
		
		
		public APQPCustUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? APQPCustUpdSp(Guid? SessionId,
		int? DerSelected,
		string DerAptrxpTypeDesc,
		int? Voucher,
		string SiteRef,
		string VendNum,
		decimal? DerDomAmtPaid,
		DateTime? DueDate,
		string DerBankCode,
		int? DerCheckSeq,
		string DerApplyVendNum,
		int? CheckNum,
		decimal? ExchRate,
		Guid? DerAppmtRowPointer,
		decimal? DerForAmtPaid,
		decimal? DerDomAmtDisc,
		decimal? DerForAmtDisc,
		string DerDiscAcct,
		string DerDiscAcctUnit1,
		string DerDiscAcctUnit2,
		string DerDiscAcctUnit3,
		string DerDiscAcctUnit4,
		decimal? AmtPaid,
		decimal? AmtDisc,
		string PoNum,
		string GrnNum,
		string InvNum,
		int? Misc1099Reportable)
		{
			RowPointerType _SessionId = SessionId;
			ListYesNoType _DerSelected = DerSelected;
			AgeDescType _DerAptrxpTypeDesc = DerAptrxpTypeDesc;
			VoucherType _Voucher = Voucher;
			SiteType _SiteRef = SiteRef;
			VendNumType _VendNum = VendNum;
			AmountType _DerDomAmtPaid = DerDomAmtPaid;
			DateType _DueDate = DueDate;
			BankCodeType _DerBankCode = DerBankCode;
			ApCheckSeqType _DerCheckSeq = DerCheckSeq;
			VendNumType _DerApplyVendNum = DerApplyVendNum;
			ApCheckNumType _CheckNum = CheckNum;
			ExchRateType _ExchRate = ExchRate;
			RowPointerType _DerAppmtRowPointer = DerAppmtRowPointer;
			AmountType _DerForAmtPaid = DerForAmtPaid;
			AmountType _DerDomAmtDisc = DerDomAmtDisc;
			AmountType _DerForAmtDisc = DerForAmtDisc;
			AcctType _DerDiscAcct = DerDiscAcct;
			UnitCode1Type _DerDiscAcctUnit1 = DerDiscAcctUnit1;
			UnitCode2Type _DerDiscAcctUnit2 = DerDiscAcctUnit2;
			UnitCode3Type _DerDiscAcctUnit3 = DerDiscAcctUnit3;
			UnitCode4Type _DerDiscAcctUnit4 = DerDiscAcctUnit4;
			AmountType _AmtPaid = AmtPaid;
			AmountType _AmtDisc = AmtDisc;
			PoNumType _PoNum = PoNum;
			GrnNumType _GrnNum = GrnNum;
			VendInvNumType _InvNum = InvNum;
			ListYesNoType _Misc1099Reportable = Misc1099Reportable;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APQPCustUpdSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerSelected", _DerSelected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerAptrxpTypeDesc", _DerAptrxpTypeDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDomAmtPaid", _DerDomAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerBankCode", _DerBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerCheckSeq", _DerCheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerApplyVendNum", _DerApplyVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerAppmtRowPointer", _DerAppmtRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerForAmtPaid", _DerForAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDomAmtDisc", _DerDomAmtDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerForAmtDisc", _DerForAmtDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDiscAcct", _DerDiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDiscAcctUnit1", _DerDiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDiscAcctUnit2", _DerDiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDiscAcctUnit3", _DerDiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerDiscAcctUnit4", _DerDiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtPaid", _AmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmtDisc", _AmtDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GrnNum", _GrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Misc1099Reportable", _Misc1099Reportable, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
