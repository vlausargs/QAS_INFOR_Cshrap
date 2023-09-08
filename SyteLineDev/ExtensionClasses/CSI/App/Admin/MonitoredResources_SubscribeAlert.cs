//PROJECT NAME: CSIAdmin
//CLASS NAME: MonitoredResources_SubscribeAlert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
	public interface IMonitoredResources_SubscribeAlert
	{
		int MonitoredResources_SubscribeAlertSp(string PublicationName,
		                                        string Username,
		                                        string Email,
		                                        byte? IsSubscribed,
		                                        ref string Infobar);
	}
	
	public class MonitoredResources_SubscribeAlert : IMonitoredResources_SubscribeAlert
	{
		IApplicationDB appDB;
		
		public MonitoredResources_SubscribeAlert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int MonitoredResources_SubscribeAlertSp(string PublicationName,
		                                               string Username,
		                                               string Email,
		                                               byte? IsSubscribed,
		                                               ref string Infobar)
		{
			NameType _PublicationName = PublicationName;
			UsernameType _Username = Username;
			EmailType _Email = Email;
			ListYesNoType _IsSubscribed = IsSubscribed;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MonitoredResources_SubscribeAlertSp";
				
				appDB.AddCommandParameter(cmd, "PublicationName", _PublicationName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsSubscribed", _IsSubscribed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
