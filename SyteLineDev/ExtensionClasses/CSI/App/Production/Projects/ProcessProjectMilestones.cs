//PROJECT NAME: CSIProjects
//CLASS NAME: ProcessProjectMilestones.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProcessProjectMilestones
	{
		int ProcessProjectMilestonesSp(Guid? ProcessID,
		                               string Process,
		                               string FromProjNum,
		                               string ToProjNum,
		                               DateTime? TransDate,
		                               string FromProductCode,
		                               string ToProductCode,
		                               ref string Infobar);
	}
	
	public class ProcessProjectMilestones : IProcessProjectMilestones
	{
		readonly IApplicationDB appDB;
		
		public ProcessProjectMilestones(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProcessProjectMilestonesSp(Guid? ProcessID,
		                                      string Process,
		                                      string FromProjNum,
		                                      string ToProjNum,
		                                      DateTime? TransDate,
		                                      string FromProductCode,
		                                      string ToProductCode,
		                                      ref string Infobar)
		{
			RowPointerType _ProcessID = ProcessID;
			StringType _Process = Process;
			HighLowCharType _FromProjNum = FromProjNum;
			HighLowCharType _ToProjNum = ToProjNum;
			DateType _TransDate = TransDate;
			HighLowCharType _FromProductCode = FromProductCode;
			HighLowCharType _ToProductCode = ToProductCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessProjectMilestonesSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProjNum", _FromProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProjNum", _ToProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProductCode", _FromProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProductCode", _ToProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
