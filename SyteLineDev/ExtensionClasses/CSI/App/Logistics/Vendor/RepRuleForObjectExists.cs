//PROJECT NAME: Logistics
//CLASS NAME: RepRuleForObjectExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class RepRuleForObjectExists : IRepRuleForObjectExists
	{
		readonly IApplicationDB appDB;
		
		
		public RepRuleForObjectExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? RepRuleForObjectExists) RepRuleForObjectExistsSp(string SourceSite,
		string RepCategory,
		string RepCatObject,
		int? RepCatObjectType,
		int? RepRuleForObjectExists)
		{
			SiteType _SourceSite = SourceSite;
			RepCategoryType _RepCategory = RepCategory;
			StringType _RepCatObject = RepCatObject;
			RepObjectType _RepCatObjectType = RepCatObjectType;
			ListYesNoType _RepRuleForObjectExists = RepRuleForObjectExists;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RepRuleForObjectExistsSp";
				
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepCategory", _RepCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepCatObject", _RepCatObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepCatObjectType", _RepCatObjectType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepRuleForObjectExists", _RepRuleForObjectExists, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RepRuleForObjectExists = _RepRuleForObjectExists;
				
				return (Severity, RepRuleForObjectExists);
			}
		}
		public int? RepRuleForObjectExistsFn(
			string SourceSite,
			string RepCategory,
			string RepCatObject,
			int? RepCatObjectType)
		{
			SiteType _SourceSite = SourceSite;
			RepCategoryType _RepCategory = RepCategory;
			StringType _RepCatObject = RepCatObject;
			RepObjectType _RepCatObjectType = RepCatObjectType;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[RepRuleForObjectExists](@SourceSite, @RepCategory, @RepCatObject, @RepCatObjectType)";

				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepCategory", _RepCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepCatObject", _RepCatObject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepCatObjectType", _RepCatObjectType, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}

	}
}
