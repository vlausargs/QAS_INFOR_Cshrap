//PROJECT NAME: Data
//CLASS NAME: GetItemPortalPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetItemPortalPrice : IGetItemPortalPrice
	{
		readonly IApplicationDB appDB;
		
		public GetItemPortalPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public Guid? GetItemPortalPriceFn(
			string Item,
			string CustNum,
			string PricingSite)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			SiteType _PricingSite = PricingSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetItemPortalPrice](@Item, @CustNum, @PricingSite)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PricingSite", _PricingSite, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<Guid?>(cmd);
				
				return Output;
			}
		}
	}
}
