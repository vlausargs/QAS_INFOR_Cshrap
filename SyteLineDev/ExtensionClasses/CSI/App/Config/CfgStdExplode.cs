//PROJECT NAME: Config
//CLASS NAME: CfgStdExplode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgStdExplode : ICfgStdExplode
	{
		readonly IApplicationDB appDB;
		
		public CfgStdExplode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgStdExplodeSp(
			string pJobtype,
			string pRunMode,
			string pConfigId,
			string pJob,
			int? pSuffix,
			string Infobar,
			int? CalcSubJobDates = 0)
		{
			LongListType _pJobtype = pJobtype;
			LongListType _pRunMode = pRunMode;
			LongListType _pConfigId = pConfigId;
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CalcSubJobDates = CalcSubJobDates;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgStdExplodeSp";
				
				appDB.AddCommandParameter(cmd, "pJobtype", _pJobtype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunMode", _pRunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CalcSubJobDates", _CalcSubJobDates, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
