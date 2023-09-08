//PROJECT NAME: Material
//CLASS NAME: GetMaxSerialNumSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetMaxSerialNumSite : IGetMaxSerialNumSite
	{
		readonly IApplicationDB appDB;
		
		
		public GetMaxSerialNumSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SerNum) GetMaxSerialNumSiteSp(string SerNumPrefix,
		string Site = null,
		string SerNum = null,
		string Item = null)
		{
			SerialPrefixType _SerNumPrefix = SerNumPrefix;
			SiteType _Site = Site;
			SerNumType _SerNum = SerNum;
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetMaxSerialNumSiteSp";
				
				appDB.AddCommandParameter(cmd, "SerNumPrefix", _SerNumPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerNum", _SerNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SerNum = _SerNum;
				
				return (Severity, SerNum);
			}
		}
	}
}
