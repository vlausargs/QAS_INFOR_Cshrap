//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBCurrencyExchangeRateMaster.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCurrencyExchangeRateMaster
	{
		int? LoadESBCurrencyExchangeRateMasterSp(DateTime? EffDate = null,
		string ActionExpression = null,
		string ToCurrCode = null,
		string FromCurrCode = null,
		decimal? DerBuyRate = null,
		string Infobar = null);
	}
	
	public class LoadESBCurrencyExchangeRateMaster : ILoadESBCurrencyExchangeRateMaster
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCurrencyExchangeRateMaster(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LoadESBCurrencyExchangeRateMasterSp(DateTime? EffDate = null,
		string ActionExpression = null,
		string ToCurrCode = null,
		string FromCurrCode = null,
		decimal? DerBuyRate = null,
		string Infobar = null)
		{
			DateTime4Type _EffDate = EffDate;
			StringType _ActionExpression = ActionExpression;
			CurrCodeType _ToCurrCode = ToCurrCode;
			CurrCodeType _FromCurrCode = FromCurrCode;
			ExchRateType _DerBuyRate = DerBuyRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCurrencyExchangeRateMasterSp";
				
				appDB.AddCommandParameter(cmd, "EffDate", _EffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCurrCode", _ToCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromCurrCode", _FromCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DerBuyRate", _DerBuyRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
