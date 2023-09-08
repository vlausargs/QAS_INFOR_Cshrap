//PROJECT NAME: Production
//CLASS NAME: RSQC_TOUpdateCOC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_TOUpdateCOC : IRSQC_TOUpdateCOC
	{
		readonly IApplicationDB appDB;
		
		public RSQC_TOUpdateCOC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) RSQC_TOUpdateCOCSp(
			string ToNum,
			int? ToLine,
			int? ToRelease,
			string Infobar)
		{
			CoNumType _ToNum = ToNum;
			CoLineType _ToLine = ToLine;
			CoReleaseType _ToRelease = ToRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_TOUpdateCOCSp";
				
				appDB.AddCommandParameter(cmd, "ToNum", _ToNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToLine", _ToLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToRelease", _ToRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
