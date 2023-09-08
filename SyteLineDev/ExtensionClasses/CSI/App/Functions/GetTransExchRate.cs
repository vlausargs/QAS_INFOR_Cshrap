//PROJECT NAME: Data
//CLASS NAME: GetTransExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetTransExchRate : IGetTransExchRate
	{
		readonly IApplicationDB appDB;
		
		public GetTransExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetTransExchRateFn(
			string FromCurrCode,
			string ToCurrCode,
			DateTime? InvoiceDate,
			int? UseBuyRate,
			decimal? PRate)
		{
			CurrCodeType _FromCurrCode = FromCurrCode;
			CurrCodeType _ToCurrCode = ToCurrCode;
			DateType _InvoiceDate = InvoiceDate;
			Flag _UseBuyRate = UseBuyRate;
			ExchRateType _PRate = PRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetTransExchRate](@FromCurrCode, @ToCurrCode, @InvoiceDate, @UseBuyRate, @PRate)";
				
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRate", _PRate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
