//PROJECT NAME: Data
//CLASS NAME: CheckWBSStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CheckWBSStatus : ICheckWBSStatus
	{
		readonly IApplicationDB appDB;
		
		public CheckWBSStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CheckWBSStatusSP(
			string ParentSP,
			string ProjNum,
			int? ProjTaskNum,
			string ProjMsNum,
			int? Voucher,
			string Infobar)
		{
			FormNameType _ParentSP = ParentSP;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _ProjTaskNum = ProjTaskNum;
			ProjMsNumType _ProjMsNum = ProjMsNum;
			VoucherType _Voucher = Voucher;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckWBSStatusSP";
				
				appDB.AddCommandParameter(cmd, "ParentSP", _ParentSP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjTaskNum", _ProjTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjMsNum", _ProjMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Voucher", _Voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
