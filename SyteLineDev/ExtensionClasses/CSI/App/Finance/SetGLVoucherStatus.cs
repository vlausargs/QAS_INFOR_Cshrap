//PROJECT NAME: Finance
//CLASS NAME: SetGLVoucherStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class SetGLVoucherStatus : ISetGLVoucherStatus
	{
		readonly IApplicationDB appDB;
		
		
		public SetGLVoucherStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar,
		int? Succ) SetGLVoucherStatusSp(string Status,
		string GLVoucher,
		string Approver = null,
		string Infobar = null,
		int? Succ = null)
		{
			GLVoucherStatusType _Status = Status;
			InvNumVoucherType _GLVoucher = GLVoucher;
			UsernameType _Approver = Approver;
			Infobar _Infobar = Infobar;
			IntType _Succ = Succ;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetGLVoucherStatusSp";
				
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GLVoucher", _GLVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Approver", _Approver, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Succ", _Succ, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Succ = _Succ;
				
				return (Severity, Infobar, Succ);
			}
		}
	}
}
