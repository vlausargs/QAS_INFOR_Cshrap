//PROJECT NAME: CSIProjects
//CLASS NAME: ProjCopyProject.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjCopyProject
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ProjCopyProjectSp(string FromType,
		string ToType,
		string FromProj,
		string ToProj,
		int? StartTask,
		int? EndTask,
		string CopyOption,
		int? RunMode,
		byte? CopyTasks,
		byte? CopyResources,
		byte? CopyRevMilestones,
		byte? CopyInvMilestones,
		string Infobar);
	}
	
	public class ProjCopyProject : IProjCopyProject
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public ProjCopyProject(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) ProjCopyProjectSp(string FromType,
		string ToType,
		string FromProj,
		string ToProj,
		int? StartTask,
		int? EndTask,
		string CopyOption,
		int? RunMode,
		byte? CopyTasks,
		byte? CopyResources,
		byte? CopyRevMilestones,
		byte? CopyInvMilestones,
		string Infobar)
		{
			ProjTypeType _FromType = FromType;
			ProjTypeType _ToType = ToType;
			ProjNumType _FromProj = FromProj;
			ProjNumType _ToProj = ToProj;
			TaskNumType _StartTask = StartTask;
			TaskNumType _EndTask = EndTask;
			StringType _CopyOption = CopyOption;
			IntType _RunMode = RunMode;
			ListYesNoType _CopyTasks = CopyTasks;
			ListYesNoType _CopyResources = CopyResources;
			ListYesNoType _CopyRevMilestones = CopyRevMilestones;
			ListYesNoType _CopyInvMilestones = CopyInvMilestones;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjCopyProjectSp";
				
				appDB.AddCommandParameter(cmd, "FromType", _FromType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToType", _ToType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProj", _FromProj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProj", _ToProj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTask", _StartTask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndTask", _EndTask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyOption", _CopyOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunMode", _RunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyTasks", _CopyTasks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyResources", _CopyResources, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyRevMilestones", _CopyRevMilestones, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyInvMilestones", _CopyInvMilestones, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
