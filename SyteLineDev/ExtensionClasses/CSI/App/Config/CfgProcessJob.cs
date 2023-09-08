//PROJECT NAME: Config
//CLASS NAME: CfgProcessJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgProcessJob : ICfgProcessJob
	{
		readonly IApplicationDB appDB;
		
		public CfgProcessJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgProcessJobSp(
			string pJob,
			int? pSuffix,
			string pType,
			string pConfigId,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			int? pCreateJob,
			int? pUpdatePrice,
			string pRunFrom,
			string Infobar)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			LongListType _pType = pType;
			ConfigIdType _pConfigId = pConfigId;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRelease = pCoRelease;
			FlagNyType _pCreateJob = pCreateJob;
			FlagNyType _pUpdatePrice = pUpdatePrice;
			LongListType _pRunFrom = pRunFrom;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgProcessJobSp";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pType", _pType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRelease", _pCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreateJob", _pCreateJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUpdatePrice", _pUpdatePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunFrom", _pRunFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
