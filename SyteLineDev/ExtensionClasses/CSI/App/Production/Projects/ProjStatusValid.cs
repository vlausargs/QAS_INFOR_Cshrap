//PROJECT NAME: CSIProjects
//CLASS NAME: ProjStatusValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjStatusValid
	{
		int ProjStatusValidSp(string ProjNum,
		                      string ProjType,
		                      string OldStatus,
		                      string NewStatus,
		                      ref string Infobar);
	}
	
	public class ProjStatusValid : IProjStatusValid
	{
		readonly IApplicationDB appDB;
		
		public ProjStatusValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjStatusValidSp(string ProjNum,
		                             string ProjType,
		                             string OldStatus,
		                             string NewStatus,
		                             ref string Infobar)
		{
			PoNumType _ProjNum = ProjNum;
			ProjTypeType _ProjType = ProjType;
			PoStatType _OldStatus = OldStatus;
			PoStatType _NewStatus = NewStatus;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjStatusValidSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjType", _ProjType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldStatus", _OldStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewStatus", _NewStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
