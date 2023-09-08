//PROJECT NAME: Codes
//CLASS NAME: GetPortalAlertParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetPortalAlertParms : IGetPortalAlertParms
	{
		readonly IApplicationDB appDB;
		
		
		public GetPortalAlertParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SiteRef,
		string Infobar,
		int? UsePortalEmail,
		string AdminUser,
		string PortalURL,
		int? LocaleID) GetPortalAlertParmsSp(string PortalType = null,
		string SiteRef = null,
		string Infobar = null,
		int? UsePortalEmail = 0,
		string AdminUser = null,
		string PortalURL = null,
		int? LocaleID = null)
		{
			AnyRefTypeType _PortalType = PortalType;
			SiteType _SiteRef = SiteRef;
			InfobarType _Infobar = Infobar;
			ListYesNoType _UsePortalEmail = UsePortalEmail;
			UsernameType _AdminUser = AdminUser;
			URLType _PortalURL = PortalURL;
			GenericIntType _LocaleID = LocaleID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPortalAlertParmsSp";
				
				appDB.AddCommandParameter(cmd, "PortalType", _PortalType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UsePortalEmail", _UsePortalEmail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AdminUser", _AdminUser, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PortalURL", _PortalURL, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LocaleID", _LocaleID, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SiteRef = _SiteRef;
				Infobar = _Infobar;
				UsePortalEmail = _UsePortalEmail;
				AdminUser = _AdminUser;
				PortalURL = _PortalURL;
				LocaleID = _LocaleID;
				
				return (Severity, SiteRef, Infobar, UsePortalEmail, AdminUser, PortalURL, LocaleID);
			}
		}
	}
}
