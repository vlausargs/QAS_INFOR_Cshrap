//PROJECT NAME: Production
//CLASS NAME: RSQC_GetVrmaParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetVrmaParm : IRSQC_GetVrmaParm
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetVrmaParm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_vrma_auto_rcpt,
		string Infobar) RSQC_GetVrmaParmSp(string o_vrma_auto_rcpt,
		string Infobar)
		{
			QCCharType _o_vrma_auto_rcpt = o_vrma_auto_rcpt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetVrmaParmSp";
				
				appDB.AddCommandParameter(cmd, "o_vrma_auto_rcpt", _o_vrma_auto_rcpt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_vrma_auto_rcpt = _o_vrma_auto_rcpt;
				Infobar = _Infobar;
				
				return (Severity, o_vrma_auto_rcpt, Infobar);
			}
		}
	}
}
