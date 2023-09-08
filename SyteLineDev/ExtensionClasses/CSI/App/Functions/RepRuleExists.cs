//PROJECT NAME: Data
//CLASS NAME: RepRuleExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class RepRuleExists : IRepRuleExists
	{
		readonly IApplicationDB appDB;
		
		public RepRuleExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RepRuleExistsFn(
			string SourceSite,
			string RepCatObject,
			int? RepCatObjectType)
		{
			SiteType _SourceSite = SourceSite;
			StringType _RepCatObject = RepCatObject;
			RepObjectType _RepCatObjectType = RepCatObjectType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[RepRuleExists](@SourceSite, @RepCatObject, @RepCatObjectType)";
				
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepCatObject", _RepCatObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepCatObjectType", _RepCatObjectType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
