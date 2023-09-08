//PROJECT NAME: Logistics
//CLASS NAME: EFTImportAppmtd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class EFTImportAppmtd : IEFTImportAppmtd
	{
		readonly IApplicationDB appDB;
		
		
		public EFTImportAppmtd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? RefRowPointer,
		string Infobar) EFTImportAppmtdSp(string VendNum,
		string InvNum,
		int? Voucher,
		string Site,
		string BankCode,
		decimal? DetailAmount,
		DateTime? EffectiveDate,
		int? CheckSeq,
		Guid? RefRowPointer,
		string Infobar)
		{
			VendNumType _VendNum = VendNum;
			InvNumType _InvNum = InvNum;
			VoucherType _Voucher = Voucher;
			SiteType _Site = Site;
			BankCodeType _BankCode = BankCode;
			AmountType _DetailAmount = DetailAmount;
			DateType _EffectiveDate = EffectiveDate;
			ApCheckSeqType _CheckSeq = CheckSeq;
			RowPointerType _RefRowPointer = RefRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EFTImportAppmtdSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DetailAmount", _DetailAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RefRowPointer = _RefRowPointer;
				Infobar = _Infobar;
				
				return (Severity, RefRowPointer, Infobar);
			}
		}
	}
}
