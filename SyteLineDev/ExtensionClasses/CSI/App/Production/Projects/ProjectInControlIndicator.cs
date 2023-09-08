//PROJECT NAME: Production
//CLASS NAME: ProjectInControlIndicator.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjectInControlIndicator : IProjectInControlIndicator
	{
		readonly IApplicationDB appDB;
		
		public ProjectInControlIndicator(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ProjectInControlIndicatorFn(
			string ProjNum,
			int? TaskNum,
			int? Seq,
			string ProjLevel,
			string Site = null)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _Seq = Seq;
			ProjCostTypeType _ProjLevel = ProjLevel;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ProjectInControlIndicator](@ProjNum, @TaskNum, @Seq, @ProjLevel, @Site)";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjLevel", _ProjLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
