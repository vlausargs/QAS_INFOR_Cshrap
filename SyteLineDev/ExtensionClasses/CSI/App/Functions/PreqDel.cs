//PROJECT NAME: Data
//CLASS NAME: PreqDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PreqDel : IPreqDel
	{
		readonly IApplicationDB appDB;
		
		public PreqDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PreqDelSp(
			string PreqitemReqNum,
			int? PreqitemReqLine,
			string PreqitemStat,
			string PreqitemPoNum,
			int? PreqitemPoLine,
			int? PreqitemPoRelease,
			string Infobar)
		{
			ReqNumType _PreqitemReqNum = PreqitemReqNum;
			ReqLineType _PreqitemReqLine = PreqitemReqLine;
			PreqitemStatusType _PreqitemStat = PreqitemStat;
			PoNumType _PreqitemPoNum = PreqitemPoNum;
			PoLineType _PreqitemPoLine = PreqitemPoLine;
			PoReleaseType _PreqitemPoRelease = PreqitemPoRelease;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PreqDelSp";
				
				appDB.AddCommandParameter(cmd, "PreqitemReqNum", _PreqitemReqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqitemReqLine", _PreqitemReqLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqitemStat", _PreqitemStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqitemPoNum", _PreqitemPoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqitemPoLine", _PreqitemPoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreqitemPoRelease", _PreqitemPoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
