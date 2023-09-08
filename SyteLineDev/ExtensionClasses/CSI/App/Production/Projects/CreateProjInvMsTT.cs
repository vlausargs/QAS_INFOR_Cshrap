//PROJECT NAME: CSIProjects
//CLASS NAME: CreateProjInvMsTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface ICreateProjInvMsTT
	{
		int? CreateProjInvMsTTSp(Guid? ProcessID,
		                         string StartingProjNum = null,
		                         string EndingProjNum = null,
		                         string StartingInvMsNum = null,
		                         string EndingInvMsNum = null,
		                         byte? EndPeriod = null,
		short? FiscalYear = null);
	}
	
	public class CreateProjInvMsTT : ICreateProjInvMsTT
	{
		readonly IApplicationDB appDB;
		
		public CreateProjInvMsTT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateProjInvMsTTSp(Guid? ProcessID,
		                                string StartingProjNum = null,
		                                string EndingProjNum = null,
		                                string StartingInvMsNum = null,
		                                string EndingInvMsNum = null,
		                                byte? EndPeriod = null,
		short? FiscalYear = null)
		{
			RowPointerType _ProcessID = ProcessID;
			ProjNumType _StartingProjNum = StartingProjNum;
			ProjNumType _EndingProjNum = EndingProjNum;
			ProjMsNumType _StartingInvMsNum = StartingInvMsNum;
			ProjMsNumType _EndingInvMsNum = EndingInvMsNum;
			FinPeriodType _EndPeriod = EndPeriod;
			FiscalYearType _FiscalYear = FiscalYear;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateProjInvMsTTSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingProjNum", _StartingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProjNum", _EndingProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvMsNum", _StartingInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvMsNum", _EndingInvMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
