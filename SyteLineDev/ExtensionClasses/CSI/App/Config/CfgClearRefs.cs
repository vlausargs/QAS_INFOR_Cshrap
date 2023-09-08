//PROJECT NAME: CSIConfig
//CLASS NAME: CfgClearRefs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Config
{
	public interface ICfgClearRefs
	{
		int CfgClearRefsSp(string pConfigId,
		                   byte? pJobFlag,
		                   string pJob,
		                   short? pSuffix,
		                   ref string Infobar);
	}
	
	public class CfgClearRefs : ICfgClearRefs
	{
		readonly IApplicationDB appDB;
		
		public CfgClearRefs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CfgClearRefsSp(string pConfigId,
		                          byte? pJobFlag,
		                          string pJob,
		                          short? pSuffix,
		                          ref string Infobar)
		{
			ConfigIdType _pConfigId = pConfigId;
			FlagNyType _pJobFlag = pJobFlag;
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgClearRefsSp";
				
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobFlag", _pJobFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
