//PROJECT NAME: Adapters
//CLASS NAME: CfgLinkGIDToID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Adapters
{
	public class CfgLinkGIDToID : ICfgLinkGIDToID
	{
		readonly IApplicationDB appDB;
		
		
		public CfgLinkGIDToID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rConfigId,
		string Infobar) CfgLinkGIDToIDSp(string pItem,
		string pCoType,
		string pCoNum,
		int? pCoLine,
		int? pCoRelease,
		string pConfigGID,
		string rConfigId,
		string Infobar)
		{
			ItemType _pItem = pItem;
			CoTypeType _pCoType = pCoType;
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			CoReleaseType _pCoRelease = pCoRelease;
			ConfigGIDType _pConfigGID = pConfigGID;
			ConfigIdType _rConfigId = rConfigId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgLinkGIDToIDSp";
				
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoType", _pCoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoRelease", _pCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigGID", _pConfigGID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rConfigId", _rConfigId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rConfigId = _rConfigId;
				Infobar = _Infobar;
				
				return (Severity, rConfigId, Infobar);
			}
		}
	}
}
