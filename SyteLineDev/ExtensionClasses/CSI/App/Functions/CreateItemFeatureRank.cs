//PROJECT NAME: Data
//CLASS NAME: CreateItemFeatureRank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CreateItemFeatureRank : ICreateItemFeatureRank
	{
		readonly IApplicationDB appDB;
		
		public CreateItemFeatureRank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CreateItemFeatureRankSp(
			string Item,
			int? FeatrankRank,
			string FeatrankFeature,
			int? FeatrankOperNum,
			string Infobar)
		{
			ItemType _Item = Item;
			FeatRankType _FeatrankRank = FeatrankRank;
			FeatureType _FeatrankFeature = FeatrankFeature;
			OperNumType _FeatrankOperNum = FeatrankOperNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateItemFeatureRankSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatrankRank", _FeatrankRank, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatrankFeature", _FeatrankFeature, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatrankOperNum", _FeatrankOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
