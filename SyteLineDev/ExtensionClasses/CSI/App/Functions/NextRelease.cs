//PROJECT NAME: Data
//CLASS NAME: NextRelease.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextRelease : INextRelease
	{
		readonly IApplicationDB appDB;
		
		public NextRelease(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CoRel,
			string Infobar) NextReleaseSp(
			string CoNum,
			int? CoLine,
			int? CoRel,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRel = CoRel;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextReleaseSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRel", _CoRel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoRel = _CoRel;
				Infobar = _Infobar;
				
				return (Severity, CoRel, Infobar);
			}
		}
	}
}
