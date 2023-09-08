//PROJECT NAME: Config
//CLASS NAME: CfgJobConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgJobConfig : ICfgJobConfig
	{
		readonly IApplicationDB appDB;
		
		
		public CfgJobConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string pJob,
		int? pSuffix,
		string CurWhse,
		string Infobar) CfgJobConfigSp(int? pCreateJob,
		string pFrom,
		string pJobtype,
		string pConfigId,
		string pCfgItem,
		string pCoNum,
		int? pCoLine,
		int? pCoRel,
		string pJob,
		int? pSuffix,
		string CurWhse,
		string Infobar,
		int? DelJobNote = 1)
		{
			FlagNyType _pCreateJob = pCreateJob;
			LongListType _pFrom = pFrom;
			LongListType _pJobtype = pJobtype;
			ConfigIdType _pConfigId = pConfigId;
			ItemType _pCfgItem = pCfgItem;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRel = pCoRel;
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			WhseType _CurWhse = CurWhse;
			InfobarType _Infobar = Infobar;
			ListYesNoType _DelJobNote = DelJobNote;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgJobConfigSp";
				
				appDB.AddCommandParameter(cmd, "pCreateJob", _pCreateJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFrom", _pFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobtype", _pJobtype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCfgItem", _pCfgItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRel", _pCoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DelJobNote", _DelJobNote, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pJob = _pJob;
				pSuffix = _pSuffix;
				CurWhse = _CurWhse;
				Infobar = _Infobar;
				
				return (Severity, pJob, pSuffix, CurWhse, Infobar);
			}
		}
	}
}
