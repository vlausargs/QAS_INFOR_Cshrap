//PROJECT NAME: Data
//CLASS NAME: NextLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextLine : INextLine
	{
		readonly IApplicationDB appDB;
		
		public NextLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CoLine,
			string Infobar) NextLineSp(
			string CoNum,
			int? CoRel,
			int? CoLine,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoReleaseType _CoRel = CoRel;
			CoLineType _CoLine = CoLine;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextLineSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRel", _CoRel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoLine = _CoLine;
				Infobar = _Infobar;
				
				return (Severity, CoLine, Infobar);
			}
		}
	}
}
