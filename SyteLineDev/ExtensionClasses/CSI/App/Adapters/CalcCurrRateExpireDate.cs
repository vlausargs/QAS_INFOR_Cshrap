//PROJECT NAME: Adapters
//CLASS NAME: CalcCurrRateExpireDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Adapters
{
	public class CalcCurrRateExpireDate : ICalcCurrRateExpireDate
	{
		readonly IApplicationDB appDB;
		
		
		public CalcCurrRateExpireDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? pExpireDate,
		string Infobar) CalcCurrRateExpireDateSp(string pDomCurrCode,
		string pForCurrCode,
		string pEffectiveDate,
		DateTime? pExpireDate,
		string Infobar)
		{
			CurrCodeType _pDomCurrCode = pDomCurrCode;
			CurrCodeType _pForCurrCode = pForCurrCode;
			StringType _pEffectiveDate = pEffectiveDate;
			DateTime4Type _pExpireDate = pExpireDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcCurrRateExpireDateSp";
				
				appDB.AddCommandParameter(cmd, "pDomCurrCode", _pDomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForCurrCode", _pForCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEffectiveDate", _pEffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pExpireDate", _pExpireDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pExpireDate = _pExpireDate;
				Infobar = _Infobar;
				
				return (Severity, pExpireDate, Infobar);
			}
		}
	}
}
