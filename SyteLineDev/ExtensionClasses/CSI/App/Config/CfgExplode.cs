//PROJECT NAME: Config
//CLASS NAME: CfgExplode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgExplode : ICfgExplode
	{
		readonly IApplicationDB appDB;
		
		public CfgExplode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgExplodeSp(
			string pJob,
			int? pSuffix,
			string pConfigId,
			string pJobType,
			string pRunMode,
			int? pUpdatePrice,
			string Infobar)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			ConfigIdType _pConfigId = pConfigId;
			LongListType _pJobType = pJobType;
			LongListType _pRunMode = pRunMode;
			FlagNyType _pUpdatePrice = pUpdatePrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgExplodeSp";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobType", _pJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunMode", _pRunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUpdatePrice", _pUpdatePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
