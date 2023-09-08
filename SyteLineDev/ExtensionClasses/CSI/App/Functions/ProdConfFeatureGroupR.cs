//PROJECT NAME: Data
//CLASS NAME: ProdConfFeatureGroupR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProdConfFeatureGroupR : IProdConfFeatureGroupR
	{
		readonly IApplicationDB appDB;
		
		public ProdConfFeatureGroupR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProdConfFeatureGroupRSp(
			string ParentItem,
			string CoitemFeatStr,
			string DisplaySequence,
			string Site)
		{
			ItemType _ParentItem = ParentItem;
			FeatStrType _CoitemFeatStr = CoitemFeatStr;
			LongListType _DisplaySequence = DisplaySequence;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProdConfFeatureGroupRSp";
				
				appDB.AddCommandParameter(cmd, "ParentItem", _ParentItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemFeatStr", _CoitemFeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplaySequence", _DisplaySequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
