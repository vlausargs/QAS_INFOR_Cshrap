//PROJECT NAME: Data
//CLASS NAME: ConvForAmtToUSD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvForAmtToUSD : IConvForAmtToUSD
	{
		readonly IApplicationDB appDB;
		
		public ConvForAmtToUSD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ConvForAmtToUSDFn(
			string ForCurrCode,
			DateTime? TransDate,
			decimal? Amount,
			string ISOCountryCode,
			decimal? ForExchRate)
		{
			CurrCodeType _ForCurrCode = ForCurrCode;
			DateTimeType _TransDate = TransDate;
			AmountType _Amount = Amount;
			ISOCountryCodeType _ISOCountryCode = ISOCountryCode;
			ExchRateType _ForExchRate = ForExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvForAmtToUSD](@ForCurrCode, @TransDate, @Amount, @ISOCountryCode, @ForExchRate)";
				
				appDB.AddCommandParameter(cmd, "ForCurrCode", _ForCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amount", _Amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOCountryCode", _ISOCountryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForExchRate", _ForExchRate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
