//PROJECT NAME: Logistics
//CLASS NAME: APQPCreateOpenDistr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class APQPCreateOpenDistr : IAPQPCreateOpenDistr
	{
		readonly IApplicationDB appDB;
		
		
		public APQPCreateOpenDistr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? APQPCreateOpenDistrSp(Guid? SessionId,
		int? Selected,
		string AptrxpTypeDesc,
		int? Voucher,
		string SiteRef,
		string VendNum,
		DateTime? DueDate,
		string BankCode,
		int? CheckSeq,
		string ApplyVendNum,
		int? CheckNum,
		decimal? DomAmtPaid,
		decimal? ExchRate,
		decimal? ForAmtPaid,
		Guid? AppmtRowPointer)
		{
			RowPointerType _SessionId = SessionId;
			ListYesNoType _Selected = Selected;
			AgeDescType _AptrxpTypeDesc = AptrxpTypeDesc;
			VoucherType _Voucher = Voucher;
			SiteType _SiteRef = SiteRef;
			VendNumType _VendNum = VendNum;
			DateType _DueDate = DueDate;
			BankCodeType _BankCode = BankCode;
			ApCheckSeqType _CheckSeq = CheckSeq;
			VendNumType _ApplyVendNum = ApplyVendNum;
			ApCheckNumType _CheckNum = CheckNum;
			AmountType _DomAmtPaid = DomAmtPaid;
			ExchRateType _ExchRate = ExchRate;
			AmountType _ForAmtPaid = ForAmtPaid;
			RowPointerType _AppmtRowPointer = AppmtRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APQPCreateOpenDistrSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpTypeDesc", _AptrxpTypeDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApplyVendNum", _ApplyVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomAmtPaid", _DomAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmtPaid", _ForAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AppmtRowPointer", _AppmtRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
