//PROJECT NAME: Production
//CLASS NAME: ProjLabrTaskNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjLabrTaskNumValid : IProjLabrTaskNumValid
	{
		readonly IApplicationDB appDB;
		
		public ProjLabrTaskNumValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TaskDesc,
			string Infobar) ProjLabrTaskNumValidSp(
			string ProjNum,
			int? TaskNum,
			string TaskDesc,
			string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			DescriptionType _TaskDesc = TaskDesc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjLabrTaskNumValidSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskDesc", _TaskDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaskDesc = _TaskDesc;
				Infobar = _Infobar;
				
				return (Severity, TaskDesc, Infobar);
			}
		}
	}
}
