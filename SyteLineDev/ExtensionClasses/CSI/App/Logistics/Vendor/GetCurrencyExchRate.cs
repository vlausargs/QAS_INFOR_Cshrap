//PROJECT NAME: CSIVendor
//CLASS NAME: GetCurrencyExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetCurrencyExchRate
	{
		(int? ReturnCode, decimal? ExchRate, string Infobar) GetCurrencyExchRateSp(string CurrCode,
		DateTime? CheckDate,
		decimal? ExchRate,
		string Infobar,
		int? UseBuyRate = 1);
	}
	
	public class GetCurrencyExchRate : IGetCurrencyExchRate
	{
		readonly IApplicationDB appDB;
		
		public GetCurrencyExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ExchRate, string Infobar) GetCurrencyExchRateSp(string CurrCode,
		DateTime? CheckDate,
		decimal? ExchRate,
		string Infobar,
		int? UseBuyRate = 1)
		{
			CurrCodeType _CurrCode = CurrCode;
			DateType _CheckDate = CheckDate;
			ExchRateType _ExchRate = ExchRate;
			Infobar _Infobar = Infobar;
			IntType _UseBuyRate = UseBuyRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCurrencyExchRateSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				Infobar = _Infobar;
				
				return (Severity, ExchRate, Infobar);
			}
		}
	}
}
