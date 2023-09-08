//PROJECT NAME: Config
//CLASS NAME: CfgProcessLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgProcessLine : ICfgProcessLine
	{
		readonly IApplicationDB appDB;
		
		public CfgProcessLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? pIPNCreated,
			string Infobar) CfgProcessLineSp(
			string pCoNum,
			int? pCoLine,
			string pConfigId,
			string pType,
			string pRunMode,
			int? pCreateJob,
			int? pUpdatePrice,
			int? pIPNCreated,
			string Infobar)
		{
			CoNumType _pCoNum = pCoNum;
			CoLineType _pCoLine = pCoLine;
			ConfigIdType _pConfigId = pConfigId;
			LongListType _pType = pType;
			LongListType _pRunMode = pRunMode;
			FlagNyType _pCreateJob = pCreateJob;
			FlagNyType _pUpdatePrice = pUpdatePrice;
			FlagNyType _pIPNCreated = pIPNCreated;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgProcessLineSp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCoLine", _pCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConfigId", _pConfigId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pType", _pType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunMode", _pRunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCreateJob", _pCreateJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pUpdatePrice", _pUpdatePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pIPNCreated", _pIPNCreated, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pIPNCreated = _pIPNCreated;
				Infobar = _Infobar;
				
				return (Severity, pIPNCreated, Infobar);
			}
		}
	}
}
