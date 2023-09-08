//PROJECT NAME: Data
//CLASS NAME: MoveProspectCommLogToCustomerCommLog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MoveProspectCommLogToCustomerCommLog : IMoveProspectCommLogToCustomerCommLog
	{
		readonly IApplicationDB appDB;
		
		public MoveProspectCommLogToCustomerCommLog(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MoveProspectCommLogToCustomerCommLogSp(
			string ProspectId,
			string CustNum,
			string Infobar)
		{
			ProspectIDType _ProspectId = ProspectId;
			CustNumType _CustNum = CustNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MoveProspectCommLogToCustomerCommLogSp";
				
				appDB.AddCommandParameter(cmd, "ProspectId", _ProspectId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
