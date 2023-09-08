//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderCreateVoucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderCreateVoucher : IVoucherBuilderCreateVoucher
	{
		readonly IApplicationDB appDB;
		
		public VoucherBuilderCreateVoucher(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PoVoucher,
			string Infobar) VoucherBuilderCreateVoucherSp(
			Guid? PProcessId,
			int? TVBRows,
			int? PAutoVoucher,
			int? PoVoucher = null,
			string Infobar = null)
		{
			RowPointerType _PProcessId = PProcessId;
			IntType _TVBRows = TVBRows;
			ListYesNoType _PAutoVoucher = PAutoVoucher;
			VoucherType _PoVoucher = PoVoucher;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VoucherBuilderCreateVoucherSp";
				
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TVBRows", _TVBRows, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAutoVoucher", _PAutoVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVoucher", _PoVoucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoVoucher = _PoVoucher;
				Infobar = _Infobar;
				
				return (Severity, PoVoucher, Infobar);
			}
		}
	}
}
