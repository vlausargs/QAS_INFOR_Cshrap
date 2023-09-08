//PROJECT NAME: Config
//CLASS NAME: CfgMakeDesc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgMakeDesc : ICfgMakeDesc
	{
		readonly IApplicationDB appDB;
		
		public CfgMakeDesc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string pDesc) CfgMakeDescSp(
			string pConfigType,
			string pCoNum,
			int? pCoLine,
			int? pCoRelease,
			string pJob,
			int? pSuffix,
			string pDesc)
		{
			ConfigTypeType _pConfigType = pConfigType;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRelease = pCoRelease;
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			LongListType _pDesc = pDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgMakeDescSp";
				
				appDB.AddCommandParameter(cmd, "pConfigType", _pConfigType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRelease", _pCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDesc", _pDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pDesc = _pDesc;
				
				return (Severity, pDesc);
			}
		}
	}
}
