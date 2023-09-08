//PROJECT NAME: Production
//CLASS NAME: ApsGntDeleteHighlight.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGntDeleteHighlight : IApsGntDeleteHighlight
	{
		readonly IApplicationDB appDB;
		
		
		public ApsGntDeleteHighlight(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGntDeleteHighlightSp(string PUsername,
		string PHighlight,
		int? PCritOnly)
		{
			UsernameType _PUsername = PUsername;
			ApsGntHighlightType _PHighlight = PHighlight;
			FlagNyType _PCritOnly = PCritOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGntDeleteHighlightSp";
				
				appDB.AddCommandParameter(cmd, "PUsername", _PUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHighlight", _PHighlight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCritOnly", _PCritOnly, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
