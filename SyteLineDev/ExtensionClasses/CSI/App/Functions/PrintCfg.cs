//PROJECT NAME: Data
//CLASS NAME: PrintCfg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PrintCfg : IPrintCfg
	{
		readonly IApplicationDB appDB;
		
		public PrintCfg(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PrintCfgSp(
			string PCoNum = null,
			int? PCoLine = 0,
			int? PCoRelease = 0,
			string PPrintConfigurationDetail = "A",
			string PInvNum = null,
			int? PInvLine = 0,
			string RptKey = null)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			StringType _PPrintConfigurationDetail = PPrintConfigurationDetail;
			InvNumType _PInvNum = PInvNum;
			InvLineType _PInvLine = PInvLine;
			StringType _RptKey = RptKey;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrintCfgSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPrintConfigurationDetail", _PPrintConfigurationDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvLine", _PInvLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RptKey", _RptKey, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
