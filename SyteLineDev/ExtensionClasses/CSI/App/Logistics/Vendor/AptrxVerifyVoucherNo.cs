//PROJECT NAME: CSIVendor
//CLASS NAME: AptrxVerifyVoucherNo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IAptrxVerifyVoucherNo
	{
		(int? ReturnCode, int? RVoucher, string CurrCode, int? FixedRate, decimal? ExchRate, string Infobar) AptrxVerifyVoucherNoSp(string PVendNum,
		string PType,
		int? RVoucher,
		string CurrCode,
		int? FixedRate,
		decimal? ExchRate,
		string Infobar,
		int? Cancellation = (byte)0);
	}
	
	public class AptrxVerifyVoucherNo : IAptrxVerifyVoucherNo
	{
		readonly IApplicationDB appDB;
		
		public AptrxVerifyVoucherNo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RVoucher, string CurrCode, int? FixedRate, decimal? ExchRate, string Infobar) AptrxVerifyVoucherNoSp(string PVendNum,
		string PType,
		int? RVoucher,
		string CurrCode,
		int? FixedRate,
		decimal? ExchRate,
		string Infobar,
		int? Cancellation = 0)
		{
			VendNumType _PVendNum = PVendNum;
			AptrxTypeType _PType = PType;
			VoucherType _RVoucher = RVoucher;
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _FixedRate = FixedRate;
			ExchRateType _ExchRate = ExchRate;
			InfobarType _Infobar = Infobar;
			ListYesNoType _Cancellation = Cancellation;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AptrxVerifyVoucherNoSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RVoucher", _RVoucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FixedRate", _FixedRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Cancellation", _Cancellation, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RVoucher = _RVoucher;
				CurrCode = _CurrCode;
				FixedRate = _FixedRate;
				ExchRate = _ExchRate;
				Infobar = _Infobar;
				
				return (Severity, RVoucher, CurrCode, FixedRate, ExchRate, Infobar);
			}
		}
	}
}
