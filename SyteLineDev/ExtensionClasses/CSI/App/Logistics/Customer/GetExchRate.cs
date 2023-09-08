//PROJECT NAME: Logistics
//CLASS NAME: GetExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetExchRate : IGetExchRate
	{
		readonly IApplicationDB appDB;
		
		
		public GetExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ExchRate,
		string Infobar) GetExchRateSp(string CustNum,
		DateTime? InvoiceDate,
		decimal? ExchRate,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			DateType _InvoiceDate = InvoiceDate;
			ExchRateType _ExchRate = ExchRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetExchRateSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				Infobar = _Infobar;
				
				return (Severity, ExchRate, Infobar);
			}
		}

		public decimal? GetExchRateFn(
			string FromCurrCode,
			string ToCurrCode,
			DateTime? InvoiceDate,
			int? UseBuyRate)
		{
			BankCodeType _FromCurrCode = FromCurrCode;
			CustNumType _ToCurrCode = ToCurrCode;
			DateType _InvoiceDate = InvoiceDate;
			Flag _UseBuyRate = UseBuyRate;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetExchRate](@FromCurrCode, @ToCurrCode, @InvoiceDate, @UseBuyRate)";

				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}
	}
}
