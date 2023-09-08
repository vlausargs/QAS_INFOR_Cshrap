//PROJECT NAME: Logistics
//CLASS NAME: APVchPostingAutoDist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class APVchPostingAutoDist : IAPVchPostingAutoDist
	{
		readonly IApplicationDB appDB;
		
		
		public APVchPostingAutoDist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) APVchPostingAutoDistSp(Guid? PSessionID,
		string PVendNum,
		int? PVoucher,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			VendNumType _PVendNum = PVendNum;
			VoucherType _PVoucher = PVoucher;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APVchPostingAutoDistSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
