//PROJECT NAME: Data
//CLASS NAME: PortalPricingOptionsExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PortalPricingOptionsExist : IPortalPricingOptionsExist
	{
		readonly IApplicationDB appDB;
		
		public PortalPricingOptionsExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PortalPricingOptionsExistFn(
			string Item,
			string CustNum)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PortalPricingOptionsExist](@Item, @CustNum)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
