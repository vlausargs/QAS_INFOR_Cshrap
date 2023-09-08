//PROJECT NAME: Data
//CLASS NAME: LivePortalItemBrkQtyPricesExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LivePortalItemBrkQtyPricesExist : ILivePortalItemBrkQtyPricesExist
	{
		readonly IApplicationDB appDB;
		
		public LivePortalItemBrkQtyPricesExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LivePortalItemBrkQtyPricesExistFn(
			string CustNum,
			string Item,
			string CurrCode)
		{
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			CurrCodeType _CurrCode = CurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[LivePortalItemBrkQtyPricesExist](@CustNum, @Item, @CurrCode)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
