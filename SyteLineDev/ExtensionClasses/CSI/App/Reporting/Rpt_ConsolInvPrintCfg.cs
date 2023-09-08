//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ConsolInvPrintCfg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ConsolInvPrintCfg : IRpt_ConsolInvPrintCfg
	{
		readonly IApplicationDB appDB;
		
		public Rpt_ConsolInvPrintCfg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? Rpt_ConsolInvPrintCfgSp(
			string PCoNum = null,
			int? PCoLine = 0,
			int? PCoRelease = 0,
			string PPrintConfigurationDetail = "A",
			string PInvNum = null,
			int? PInvLine = 0)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			StringType _PPrintConfigurationDetail = PPrintConfigurationDetail;
			InvNumType _PInvNum = PInvNum;
			InvLineType _PInvLine = PInvLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ConsolInvPrintCfgSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintConfigurationDetail", _PPrintConfigurationDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvLine", _PInvLine, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
