//PROJECT NAME: Data
//CLASS NAME: PortalOrderReceivedAlert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PortalOrderReceivedAlert : IPortalOrderReceivedAlert
	{
		readonly IApplicationDB appDB;
		
		public PortalOrderReceivedAlert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PortalOrderReceivedAlertSp(
			string CustNum,
			string CoNum,
			string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CoNumType _CoNum = CoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalOrderReceivedAlertSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
