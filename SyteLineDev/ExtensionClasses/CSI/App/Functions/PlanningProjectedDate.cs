//PROJECT NAME: Data
//CLASS NAME: PlanningProjectedDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PlanningProjectedDate : IPlanningProjectedDate
	{
		readonly IApplicationDB appDB;
		
		public PlanningProjectedDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? PlanningProjectedDateFn(
			string PProjNum,
			int? PProjTaskNum,
			string Site = null)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PProjTaskNum = PProjTaskNum;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PlanningProjectedDate](@PProjNum, @PProjTaskNum, @Site)";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjTaskNum", _PProjTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
