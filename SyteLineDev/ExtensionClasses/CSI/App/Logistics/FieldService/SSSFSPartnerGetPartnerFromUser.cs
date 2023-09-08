//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPartnerGetPartnerFromUser.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPartnerGetPartnerFromUser : ISSSFSPartnerGetPartnerFromUser
	{
		readonly IApplicationDB appDB;
		
		public SSSFSPartnerGetPartnerFromUser(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Partner,
			string Infobar) SSSFSPartnerGetPartnerFromUserSp(
			string UserName,
			string Partner,
			string Infobar)
		{
			UsernameType _UserName = UserName;
			FSPartnerType _Partner = Partner;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSPartnerGetPartnerFromUserSp";
				
				appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Partner", _Partner, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Partner = _Partner;
				Infobar = _Infobar;
				
				return (Severity, Partner, Infobar);
			}
		}
	}
}
