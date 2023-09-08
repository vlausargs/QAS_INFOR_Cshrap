//PROJECT NAME: Data
//CLASS NAME: HierlistGetActiveSites.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class HierlistGetActiveSites : IHierlistGetActiveSites
	{
		readonly IApplicationDB appDB;
		
		public HierlistGetActiveSites(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PNumHierarchies,
			string PHierarchyList,
			string Infobar) HierlistGetActiveSitesSp(
			string PEntity,
			string PHierarchy,
			DateTime? PStartDate,
			DateTime? PEndDate,
			int? PNumHierarchies,
			string PHierarchyList,
			string Infobar)
		{
			SiteType _PEntity = PEntity;
			LongListType _PHierarchy = PHierarchy;
			CurrentDateType _PStartDate = PStartDate;
			CurrentDateType _PEndDate = PEndDate;
			IntType _PNumHierarchies = PNumHierarchies;
			LongListType _PHierarchyList = PHierarchyList;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "HierlistGetActiveSitesSp";
				
				appDB.AddCommandParameter(cmd, "PEntity", _PEntity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PHierarchy", _PHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartDate", _PStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndDate", _PEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNumHierarchies", _PNumHierarchies, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PHierarchyList", _PHierarchyList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PNumHierarchies = _PNumHierarchies;
				PHierarchyList = _PHierarchyList;
				Infobar = _Infobar;
				
				return (Severity, PNumHierarchies, PHierarchyList, Infobar);
			}
		}
	}
}
