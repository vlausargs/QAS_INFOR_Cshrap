//PROJECT NAME: Logistics
//CLASS NAME: ExchRateValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ExchRateValid : IExchRateValid
	{
		readonly IApplicationDB appDB;
		
		
		public ExchRateValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ExchRateValidSp(string CurrCode,
		DateTime? TransDate,
		decimal? ExchRate,
		string Infobar)
		{
			CurrCodeType _CurrCode = CurrCode;
			DateType _TransDate = TransDate;
			ExchRateType _ExchRate = ExchRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExchRateValidSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
