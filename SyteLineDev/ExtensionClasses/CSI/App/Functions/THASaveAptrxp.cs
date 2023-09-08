//PROJECT NAME: Data
//CLASS NAME: THASaveAptrxp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THASaveAptrxp : ITHASaveAptrxp
	{
		readonly IApplicationDB appDB;
		
		public THASaveAptrxp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) THASaveAptrxpSp(
			string VendNum,
			int? Voucher,
			int? VouchSeq,
			string PType,
			string Sites,
			int? HoldFlag,
			string VInvNum,
			DateTime? InvDate,
			DateTime? DiscDate,
			DateTime? DueDate,
			int? CheckNum,
			int? Active,
			int? OldVoucher,
			int? OldVouchSeq,
			string Infobar)
		{
			VendNumType _VendNum = VendNum;
			VoucherType _Voucher = Voucher;
			VouchSeqType _VouchSeq = VouchSeq;
			AptrxpTypeType _PType = PType;
			SiteType _Sites = Sites;
			ListYesNoType _HoldFlag = HoldFlag;
			VendInvNumType _VInvNum = VInvNum;
			DateType _InvDate = InvDate;
			DateType _DiscDate = DiscDate;
			DateType _DueDate = DueDate;
			ApCheckNumType _CheckNum = CheckNum;
			ListYesNoType _Active = Active;
			VoucherType _OldVoucher = OldVoucher;
			VouchSeqType _OldVouchSeq = OldVouchSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THASaveAptrxpSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VouchSeq", _VouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sites", _Sites, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoldFlag", _HoldFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VInvNum", _VInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscDate", _DiscDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldVoucher", _OldVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldVouchSeq", _OldVouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
