//PROJECT NAME: Config
//CLASS NAME: CfgDoConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgDoConfig : ICfgDoConfig
	{
		readonly IApplicationDB appDB;
		
		
		public CfgDoConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? DoRefresh,
		string Infobar,
		int? Warning) CfgDoConfigSp(string pConfigId,
		string pCep,
		int? pCreateJob,
		string pRunFrom,
		string pRunMode,
		int? pUpdatePrice,
		int? DoRefresh,
		string Infobar,
		int? Warning)
		{
			ConfigIdType _pConfigId = pConfigId;
			LongListType _pCep = pCep;
			FlagNyType _pCreateJob = pCreateJob;
			LongListType _pRunFrom = pRunFrom;
			LongListType _pRunMode = pRunMode;
			FlagNyType _pUpdatePrice = pUpdatePrice;
			FlagNyType _DoRefresh = DoRefresh;
			InfobarType _Infobar = Infobar;
			FlagNyType _Warning = Warning;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgDoConfigSp";
				
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCep", _pCep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreateJob", _pCreateJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunFrom", _pRunFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunMode", _pRunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUpdatePrice", _pUpdatePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DoRefresh", _DoRefresh, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Warning", _Warning, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DoRefresh = _DoRefresh;
				Infobar = _Infobar;
				Warning = _Warning;
				
				return (Severity, DoRefresh, Infobar, Warning);
			}
		}
	}
}
