//PROJECT NAME: Admin
//CLASS NAME: BI_Create_Union_View.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public class BI_Create_Union_View : IBI_Create_Union_View
	{
		readonly IApplicationDB appDB;
		
		public BI_Create_Union_View(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? BI_Create_Union_ViewSp(
			string SourceViewName = null,
			string SiteColumnName = null,
			string TargetViewName = null)
		{
			StringType _SourceViewName = SourceViewName;
			StringType _SiteColumnName = SiteColumnName;
			StringType _TargetViewName = TargetViewName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BI_Create_Union_ViewSp";
				
				appDB.AddCommandParameter(cmd, "SourceViewName", _SourceViewName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteColumnName", _SiteColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TargetViewName", _TargetViewName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
