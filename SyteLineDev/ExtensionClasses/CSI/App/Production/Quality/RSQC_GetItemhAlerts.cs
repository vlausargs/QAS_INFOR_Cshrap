//PROJECT NAME: Production
//CLASS NAME: RSQC_GetItemhAlerts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetItemhAlerts : IRSQC_GetItemhAlerts
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetItemhAlerts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Messages,
		string Infobar) RSQC_GetItemhAlertsSp(string RcvrNum,
		string Messages,
		string Infobar)
		{
			QCDocNumType _RcvrNum = RcvrNum;
			InfobarType _Messages = Messages;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetItemhAlertsSp";
				
				appDB.AddCommandParameter(cmd, "RcvrNum", _RcvrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Messages", _Messages, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Messages = _Messages;
				Infobar = _Infobar;
				
				return (Severity, Messages, Infobar);
			}
		}
	}
}
