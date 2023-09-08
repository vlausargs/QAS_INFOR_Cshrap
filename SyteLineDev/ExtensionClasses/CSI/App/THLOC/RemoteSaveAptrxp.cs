//PROJECT NAME: THLOC
//CLASS NAME: RemoteSaveAptrxp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.THLOC
{
	public class RemoteSaveAptrxp : IRemoteSaveAptrxp
	{
		readonly IApplicationDB appDB;
		
		
		public RemoteSaveAptrxp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RemoteSaveAptrxpSp(string VendNum,
		int? Voucher,
		int? VouchSeq,
		string PType,
		int? HoldFlag,
		string VInvNum,
		DateTime? InvDate,
		DateTime? DiscDate,
		DateTime? DueDate,
		int? CheckNum,
		int? Active,
		int? OldVoucher,
		int? OldVouchSeq,
		int? Misc1099Reportable,
		string Infobar)
		{
			VendNumType _VendNum = VendNum;
			VoucherType _Voucher = Voucher;
			VouchSeqType _VouchSeq = VouchSeq;
			AptrxpTypeType _PType = PType;
			ListYesNoType _HoldFlag = HoldFlag;
			VendInvNumType _VInvNum = VInvNum;
			DateType _InvDate = InvDate;
			DateType _DiscDate = DiscDate;
			DateType _DueDate = DueDate;
			ApCheckNumType _CheckNum = CheckNum;
			ListYesNoType _Active = Active;
			VoucherType _OldVoucher = OldVoucher;
			VouchSeqType _OldVouchSeq = OldVouchSeq;
			ListYesNoType _Misc1099Reportable = Misc1099Reportable;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteSaveAptrxpSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VouchSeq", _VouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HoldFlag", _HoldFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VInvNum", _VInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DiscDate", _DiscDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Active", _Active, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldVoucher", _OldVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldVouchSeq", _OldVouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Misc1099Reportable", _Misc1099Reportable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
