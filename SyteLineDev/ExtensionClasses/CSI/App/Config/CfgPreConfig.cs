//PROJECT NAME: Config
//CLASS NAME: CfgPreConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgPreConfig : ICfgPreConfig
	{
		readonly IApplicationDB appDB;
		
		
		public CfgPreConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string pItem,
		string CfgModel,
		string Infobar) CfgPreConfigSp(string pPermit,
		string pCep,
		string pItem,
		string CfgModel,
		string pCoNum,
		int? pCoLine,
		int? pCoRelease,
		string pJob,
		int? pSuffix,
		string pRunFrom,
		string ShipSite,
		string Infobar)
		{
			LongListType _pPermit = pPermit;
			LongListType _pCep = pCep;
			ItemType _pItem = pItem;
			ConfigModelType _CfgModel = CfgModel;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRelease = pCoRelease;
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			LongListType _pRunFrom = pRunFrom;
			SiteType _ShipSite = ShipSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgPreConfigSp";
				
				appDB.AddCommandParameter(cmd, "pPermit", _pPermit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCep", _pCep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CfgModel", _CfgModel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRelease", _pCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunFrom", _pRunFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipSite", _ShipSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pItem = _pItem;
				CfgModel = _CfgModel;
				Infobar = _Infobar;
				
				return (Severity, pItem, CfgModel, Infobar);
			}
		}
	}
}
