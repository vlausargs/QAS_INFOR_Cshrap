//PROJECT NAME: CSIMaterial
//CLASS NAME: GetMaxLotNumSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetMaxLotNumSite
	{
		(int? ReturnCode, string KeyVal) GetMaxLotNumSiteSp(string LotPrefix,
		string Site = null,
		string KeyVal = null,
		string Item = null);
	}
	
	public class GetMaxLotNumSite : IGetMaxLotNumSite
	{
		readonly IApplicationDB appDB;
		
		public GetMaxLotNumSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string KeyVal) GetMaxLotNumSiteSp(string LotPrefix,
		string Site = null,
		string KeyVal = null,
		string Item = null)
		{
			LotPrefixType _LotPrefix = LotPrefix;
			SiteType _Site = Site;
			LotType _KeyVal = KeyVal;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMaxLotNumSiteSp";
				
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyVal", _KeyVal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				KeyVal = _KeyVal;
				
				return (Severity, KeyVal);
			}
		}
	}
}
