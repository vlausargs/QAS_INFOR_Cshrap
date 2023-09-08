//PROJECT NAME: CSIMaterial
//CLASS NAME: ProdConfExcludeOptCode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IProdConfExcludeOptCode
	{
		(int? ReturnCode, string ExcludeOptCode) ProdConfExcludeOptCodeSp(string Feature,
		string FeatStr,
		string Item,
		int? OperNum,
		string ExcludeOptCode,
		string Site = null);
	}
	
	public class ProdConfExcludeOptCode : IProdConfExcludeOptCode
	{
		readonly IApplicationDB appDB;
		
		public ProdConfExcludeOptCode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ExcludeOptCode) ProdConfExcludeOptCodeSp(string Feature,
		string FeatStr,
		string Item,
		int? OperNum,
		string ExcludeOptCode,
		string Site = null)
		{
			FeatureType _Feature = Feature;
			FeatStrType _FeatStr = FeatStr;
			ItemType _Item = Item;
			OperNumType _OperNum = OperNum;
			LongListType _ExcludeOptCode = ExcludeOptCode;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProdConfExcludeOptCodeSp";
				
				appDB.AddCommandParameter(cmd, "Feature", _Feature, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExcludeOptCode", _ExcludeOptCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExcludeOptCode = _ExcludeOptCode;
				
				return (Severity, ExcludeOptCode);
			}
		}
	}
}
