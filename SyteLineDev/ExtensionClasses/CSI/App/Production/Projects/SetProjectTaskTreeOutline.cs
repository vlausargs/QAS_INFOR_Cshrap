//PROJECT NAME: Production
//CLASS NAME: SetProjectTaskTreeOutline.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class SetProjectTaskTreeOutline : ISetProjectTaskTreeOutline
	{
		readonly IApplicationDB appDB;
		
		
		public SetProjectTaskTreeOutline(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutLineNumber,
		string Infobar) SetProjectTaskTreeOutlineSp(string ProjNum,
		int? TaskNum,
		int? ParentTaskNum,
		string IndentOrOutdent = "INDENT",
		string OutLineNumber = null,
		string Infobar = null)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			TaskNumType _ParentTaskNum = ParentTaskNum;
			StringType _IndentOrOutdent = IndentOrOutdent;
			StringType _OutLineNumber = OutLineNumber;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetProjectTaskTreeOutlineSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentTaskNum", _ParentTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IndentOrOutdent", _IndentOrOutdent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutLineNumber", _OutLineNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutLineNumber = _OutLineNumber;
				Infobar = _Infobar;
				
				return (Severity, OutLineNumber, Infobar);
			}
		}
	}
}
