//PROJECT NAME: Finance
//CLASS NAME: CHSValidateCurrency.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSValidateCurrency : ICHSValidateCurrency
	{
		readonly IApplicationDB appDB;
		
		public CHSValidateCurrency(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Amt_Format,
			string Infobar) CHSValidateCurrencySp(
			string CurrCode,
			DateTime? TransDate,
			decimal? ExchRate,
			string Amt_Format,
			string Infobar)
		{
			CurrCodeType _CurrCode = CurrCode;
			DateType _TransDate = TransDate;
			ExchRateType _ExchRate = ExchRate;
			InputMaskType _Amt_Format = Amt_Format;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSValidateCurrencySp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Amt_Format", _Amt_Format, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Amt_Format = _Amt_Format;
				Infobar = _Infobar;
				
				return (Severity, Amt_Format, Infobar);
			}
		}
	}
}
