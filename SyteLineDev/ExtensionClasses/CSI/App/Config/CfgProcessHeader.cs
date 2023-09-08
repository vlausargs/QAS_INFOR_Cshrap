//PROJECT NAME: Config
//CLASS NAME: CfgProcessHeader.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgProcessHeader : ICfgProcessHeader
	{
		readonly IApplicationDB appDB;
		
		public CfgProcessHeader(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CfgProcessHeaderSp(
			string pCoNum,
			string pType,
			string pRunMode,
			string Infobar)
		{
			CoNumType _pCoNum = pCoNum;
			LongListType _pType = pType;
			LongListType _pRunMode = pRunMode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgProcessHeaderSp";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pType", _pType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunMode", _pRunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
