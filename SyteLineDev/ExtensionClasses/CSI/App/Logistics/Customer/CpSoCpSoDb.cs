//PROJECT NAME: Logistics
//CLASS NAME: CpSoCpSoDb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoCpSoDb : ICpSoCpSoDb
	{
		readonly IApplicationDB appDB;
		
		public CpSoCpSoDb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CpSoCpSoDbSp(
			string PCoNum,
			int? PCoLine,
			string PCoOrigSite,
			int? PHasCfg,
			string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			SiteType _PCoOrigSite = PCoOrigSite;
			FlagNyType _PHasCfg = PHasCfg;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoCpSoDbSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoOrigSite", _PCoOrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHasCfg", _PHasCfg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
