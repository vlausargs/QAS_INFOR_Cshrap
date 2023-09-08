//PROJECT NAME: Data
//CLASS NAME: GetQtyAvailable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetQtyAvailable : IGetQtyAvailable
	{
		readonly IApplicationDB appDB;
		
		public GetQtyAvailable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetQtyAvailableFn(
			string Item,
			int? LocaleID,
			string Site)
		{
			ItemType _Item = Item;
			GenericIntType _LocaleID = LocaleID;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetQtyAvailable](@Item, @LocaleID, @Site)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocaleID", _LocaleID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
