//PROJECT NAME: Logistics
//CLASS NAME: CheckInvLength.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckInvLength : ICheckInvLength
	{
		readonly IApplicationDB appDB;
		
		
		public CheckInvLength(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Result,
		string Infobar) CheckInvLengthSp(int? Result,
		string Infobar)
		{
			IntType _Result = Result;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckInvLengthSp";
				
				appDB.AddCommandParameter(cmd, "Result", _Result, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Result = _Result;
				Infobar = _Infobar;
				
				return (Severity, Result, Infobar);
			}
		}
	}
}
