//PROJECT NAME: Data
//CLASS NAME: GetumcfAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetumcfAll : IGetumcfAll
	{
		readonly IApplicationDB appDB;
		
		public GetumcfAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetumcfAllFn(
			string OtherUM,
			string Item,
			string VendNum,
			string Area,
			string Site = null)
		{
			UMType _OtherUM = OtherUM;
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			StringType _Area = Area;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetumcfAll](@OtherUM, @Item, @VendNum, @Area, @Site)";
				
				appDB.AddCommandParameter(cmd, "OtherUM", _OtherUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Area", _Area, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
