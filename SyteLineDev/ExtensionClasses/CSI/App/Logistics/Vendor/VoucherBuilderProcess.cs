//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderProcess : IVoucherBuilderProcess
	{
		readonly IApplicationDB appDB;
		
		
		public VoucherBuilderProcess(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PoVoucher,
		string PBuilderVoucherNum,
		string Infobar) VoucherBuilderProcessSp(Guid? PProcessID,
		string PVendNum,
		int? PAutoVoucher,
		string CalledFrom = "PurchaseOrderReceiving",
		int? PoVoucher = null,
		string PBuilderVoucherNum = null,
		string Infobar = null)
		{
			RowPointerType _PProcessID = PProcessID;
			VendNumType _PVendNum = PVendNum;
			ListYesNoType _PAutoVoucher = PAutoVoucher;
			StringType _CalledFrom = CalledFrom;
			VoucherType _PoVoucher = PoVoucher;
			BuilderVoucherType _PBuilderVoucherNum = PBuilderVoucherNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoucherBuilderProcessSp";
				
				appDB.AddCommandParameter(cmd, "PProcessID", _PProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAutoVoucher", _PAutoVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVoucher", _PoVoucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBuilderVoucherNum", _PBuilderVoucherNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoVoucher = _PoVoucher;
				PBuilderVoucherNum = _PBuilderVoucherNum;
				Infobar = _Infobar;
				
				return (Severity, PoVoucher, PBuilderVoucherNum, Infobar);
			}
		}
	}
}
