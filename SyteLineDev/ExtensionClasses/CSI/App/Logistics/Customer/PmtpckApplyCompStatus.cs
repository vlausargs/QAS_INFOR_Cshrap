//PROJECT NAME: CSICustomer
//CLASS NAME: PmtpckApplyCompStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPmtpckApplyCompStatus
	{
		int PmtpckApplyCompStatusSp(ref string WarningMsgs,
		                            ref string SuccessMsg);
	}
	
	public class PmtpckApplyCompStatus : IPmtpckApplyCompStatus
	{
		readonly IApplicationDB appDB;
		
		public PmtpckApplyCompStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PmtpckApplyCompStatusSp(ref string WarningMsgs,
		                                   ref string SuccessMsg)
		{
			InfobarType _WarningMsgs = WarningMsgs;
			InfobarType _SuccessMsg = SuccessMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmtpckApplyCompStatusSp";
				
				appDB.AddCommandParameter(cmd, "WarningMsgs", _WarningMsgs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SuccessMsg", _SuccessMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				WarningMsgs = _WarningMsgs;
				SuccessMsg = _SuccessMsg;
				
				return Severity;
			}
		}
	}
}
