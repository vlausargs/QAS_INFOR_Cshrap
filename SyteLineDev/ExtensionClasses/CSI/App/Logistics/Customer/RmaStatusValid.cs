//PROJECT NAME: CSICustomer
//CLASS NAME: RmaStatusValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRmaStatusValid
	{
		int RmaStatusValidSp(string RMANum,
		                     string OldStatus,
		                     string Status,
		                     ref string Infobar);
	}
	
	public class RmaStatusValid : IRmaStatusValid
	{
		readonly IApplicationDB appDB;
		
		public RmaStatusValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int RmaStatusValidSp(string RMANum,
		                            string OldStatus,
		                            string Status,
		                            ref string Infobar)
		{
			RmaNumType _RMANum = RMANum;
			RmaStatusType _OldStatus = OldStatus;
			RmaStatusType _Status = Status;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaStatusValidSp";
				
				appDB.AddCommandParameter(cmd, "RMANum", _RMANum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStatus", _OldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
