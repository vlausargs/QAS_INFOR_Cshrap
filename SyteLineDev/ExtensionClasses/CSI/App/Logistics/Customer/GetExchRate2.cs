//PROJECT NAME: Logistics
//CLASS NAME: GetExchRate2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetExchRate2 : IGetExchRate2
	{
		readonly IApplicationDB appDB;
		
		
		public GetExchRate2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ExchRate,
		string Infobar) GetExchRate2Sp(string FromCurrCode,
		string ToCurrCode,
		DateTime? InvoiceDate,
		decimal? ExchRate,
		string Infobar)
		{
			BankCodeType _FromCurrCode = FromCurrCode;
			CustNumType _ToCurrCode = ToCurrCode;
			DateType _InvoiceDate = InvoiceDate;
			ExchRateType _ExchRate = ExchRate;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetExchRate2Sp";
				
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvoiceDate", _InvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				Infobar = _Infobar;
				
				return (Severity, ExchRate, Infobar);
			}
		}
	}
}
