//PROJECT NAME: Production
//CLASS NAME: CopyNotesFromOrigSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class CopyNotesFromOrigSite : ICopyNotesFromOrigSite
	{
		readonly IApplicationDB appDB;
		
		public CopyNotesFromOrigSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CopyNotesFromOrigSiteSp(
			string CoNum,
			string CoType,
			string SourceSite,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoTypeType _CoType = CoType;
			SiteType _SourceSite = SourceSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyNotesFromOrigSiteSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
