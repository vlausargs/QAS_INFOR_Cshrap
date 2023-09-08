//PROJECT NAME: Codes
//CLASS NAME: GetCustomerSellRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class GetCustomerSellRate : IGetCustomerSellRate
	{
		readonly IApplicationDB appDB;
		
		
		public GetCustomerSellRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? SellRate) GetCustomerSellRateSp(string DomesticCurrCode,
		string CustomerCurrCode,
		decimal? SellRate)
		{
			CurrCodeType _DomesticCurrCode = DomesticCurrCode;
			CurrCodeType _CustomerCurrCode = CustomerCurrCode;
			ExchRateType _SellRate = SellRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCustomerSellRateSp";
				
				appDB.AddCommandParameter(cmd, "DomesticCurrCode", _DomesticCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerCurrCode", _CustomerCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SellRate", _SellRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SellRate = _SellRate;
				
				return (Severity, SellRate);
			}
		}
	}
}
