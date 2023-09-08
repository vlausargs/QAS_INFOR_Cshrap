//PROJECT NAME: Data
//CLASS NAME: DisallowNonIntranetLicenseSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisallowNonIntranetLicenseSite : IDisallowNonIntranetLicenseSite
	{
		readonly IApplicationDB appDB;
		
		public DisallowNonIntranetLicenseSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) DisallowNonIntranetLicenseSiteSp(
			string FormName,
			string Infobar)
		{
			StringType _FormName = FormName;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DisallowNonIntranetLicenseSiteSp";
				
				appDB.AddCommandParameter(cmd, "FormName", _FormName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
