//PROJECT NAME: Config
//CLASS NAME: CopyRoutingBOMPredisplay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CopyRoutingBOMPredisplay : ICopyRoutingBOMPredisplay
	{
		readonly IApplicationDB appDB;
		
		
		public CopyRoutingBOMPredisplay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CopyRoutingBOMPredisplaySp(string pOldConfigID,
		string pNewCoNum,
		int? pNewCoLine,
		int? pNewCoRelease,
		string pNewJob,
		int? pNewSuffix,
		string pNewItem,
		string pRecType,
		string pKey1,
		string pKey2,
		string pKey3,
		string pNewConfigGid,
		string pConfigurator,
		string Infobar)
		{
			ConfigIdType _pOldConfigID = pOldConfigID;
			CoNumType _pNewCoNum = pNewCoNum;
			CoLineType _pNewCoLine = pNewCoLine;
			CoReleaseType _pNewCoRelease = pNewCoRelease;
			JobType _pNewJob = pNewJob;
			SuffixType _pNewSuffix = pNewSuffix;
			ItemType _pNewItem = pNewItem;
			StringType _pRecType = pRecType;
			StringType _pKey1 = pKey1;
			StringType _pKey2 = pKey2;
			StringType _pKey3 = pKey3;
			ConfigGIDType _pNewConfigGid = pNewConfigGid;
			ConfiguratorType _pConfigurator = pConfigurator;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyRoutingBOMPredisplaySp";
				
				appDB.AddCommandParameter(cmd, "pOldConfigID", _pOldConfigID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewCoNum", _pNewCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewCoLine", _pNewCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewCoRelease", _pNewCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewJob", _pNewJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewSuffix", _pNewSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewItem", _pNewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRecType", _pRecType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pKey1", _pKey1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pKey2", _pKey2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pKey3", _pKey3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNewConfigGid", _pNewConfigGid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigurator", _pConfigurator, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
