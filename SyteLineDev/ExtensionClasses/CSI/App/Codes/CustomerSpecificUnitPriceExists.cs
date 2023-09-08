//PROJECT NAME: Data
//CLASS NAME: CustomerSpecificUnitPriceExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CustomerSpecificUnitPriceExists : ICustomerSpecificUnitPriceExists
	{
		readonly IApplicationDB appDB;

		public CustomerSpecificUnitPriceExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? CustomerSpecificUnitPriceExistsFn(
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
				cmd.CommandText = "SELECT  dbo.[CustomerSpecificUnitPriceExists](@CustNum, @Item, @CurrCode)";

				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
