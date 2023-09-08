//PROJECT NAME: Data
//CLASS NAME: ProdConfFeatureMaterialR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProdConfFeatureMaterialR : IProdConfFeatureMaterialR
	{
		readonly IApplicationDB appDB;
		
		public ProdConfFeatureMaterialR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProdConfFeatureMaterialRSp(
			string ParentItem,
			string Feature,
			string CoNum,
			int? CoLine,
			string Site)
		{
			ItemType _ParentItem = ParentItem;
			FeatureType _Feature = Feature;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProdConfFeatureMaterialRSp";
				
				appDB.AddCommandParameter(cmd, "ParentItem", _ParentItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Feature", _Feature, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
